
﻿CREATE TRIGGER trg_BR_Approved
ON BloodRequirement
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    IF UPDATE(Status)
    BEGIN
        -- Chỉ xử lý các bản ghi có Status mới là 'Approved'
        DECLARE @Approved TABLE (ID INT);
        INSERT INTO @Approved(ID)
        SELECT ID FROM inserted WHERE Status = 'Approved';

        -- 1. Chèn vào BloodSupplyDetail
        INSERT INTO BloodSupplyDetail (RequirementDetailID, BloodDetailID, Amount)
        SELECT 
            d.DetailID,
            bd.BloodDetailID,
            d.Amount
        FROM BloodRequirementDetail d
        JOIN @Approved i ON d.RequirementID = i.ID
        CROSS APPLY (
            SELECT TOP 1 bd.BloodDetailID
            FROM BloodDetail bd
            JOIN BloodStock bs ON bd.BloodID = bs.BloodID
            WHERE bd.Status = 'Available'
              AND bs.BloodType = d.BloodType
            ORDER BY bd.ExpiredDate
        ) AS bd;

        -- 2. Cập nhật trạng thái máu thành 'Used'
        UPDATE bd
        SET bd.Status = 'Used'
        FROM BloodDetail bd
        JOIN BloodSupplyDetail sd ON bd.BloodDetailID = sd.BloodDetailID
        JOIN BloodRequirementDetail d ON sd.RequirementDetailID = d.DetailID
        JOIN @Approved i ON d.RequirementID = i.ID;
        -- 3. Cập nhật tổng số lượng máu trong BloodStock
        UPDATE bs
        SET bs.Amount = bs.Amount - d.Amount
        FROM BloodStock bs
        JOIN BloodRequirementDetail d ON bs.BloodType = d.BloodType
        JOIN @Approved i ON d.RequirementID = i.ID;
        END
END

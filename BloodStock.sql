CREATE OR ALTER TRIGGER trg_BloodStock_Update
ON [dbo].[BloodStock]
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra các bản ghi vừa được update có Amount < 1000
    INSERT INTO [dbo].[Notifications] 
        (ObjectID, Title, Message, CreateAt, IsRead)
    SELECT 
        N'admin', -- ObjectID là 'admin'
        N'Cảnh báo tồn kho máu thấp', -- Tiêu đề thông báo
        N'Số lượng máu nhóm ' + i.BloodType + ' tồn kho dưới 1000 đơn vị. Vui lòng bổ sung thêm máu.', -- Nội dung thông báo
        GETDATE(), -- Thời gian tạo thông báo
        0 -- IsRead mặc định là chưa đọc
    FROM inserted i
    WHERE i.Amount < 1000;
END;
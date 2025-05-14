create database BloodBank
go

 
use BloodBank
go

-- Tạo bảng Donor (Người hiến máu)
CREATE TABLE Donor (
DonorID int PRIMARY KEY identity (1,1),
--UserName nChar(50) not null,
--Password nChar(30) not null,
FullName nvarchar(100) not null,
BloodType nvarchar(3) null, -- TỐI ĐA 3 KÝ TỰ
BirthDate date not null,
PhoneNumber nchar(11) not null,
Address nvarchar(255) not null,
LastDonationDate date NULL,
Gender nvarchar(10) not null,
Email nvarchar(100) null,
);
GO

-- Tạo bảng ReceivingUnit (Đơn vị nhận máu) -- Danh sách có sẵn, chỉ có admin mới được tạo thêm chớ không có đăng ký
CREATE TABLE ReceivingUnit (
RU_ID nChar(10) primary key,
UnitName nvarchar(100) not null,
ContactName nvarchar(50) not null, --Tên người đại diện
Address nvarchar(255) not null,
PhoneNumber nvarchar(11) NOT NULL, --Có thể là sđt bệnh viện hoặc sđt người đại diện
Email NVARCHAR(100) NOT NULL,
UnitType NVARCHAR(50) NULL DEFAULT 'Hospital', --Hopistal/Clinic/Nursing Home
);
GO

-- Tạo bảng BloodStock (Kho máu)
CREATE TABLE BloodStock (
BloodID int primary key identity(1,1),
BloodType nvarchar(10) not null,
Amount float not null, -- đơn vị ml
);
GO

-- Tạo bảng BloodDetail (Chi tiết máu từ donor)
CREATE TABLE BloodDetail(
BloodDetailID int primary key identity(1,1) not null,
BloodID int not null, --Liên kết với bảng BloodStock
CollectionDate datetime not null,
ExpiredDate datetime not null,
Status nvarchar(50) not null DEFAULT 'Used', -- Used, Available, Quarantine 
DonorID int null, --Liên kết với bảng donor

foreign key (BloodID) references BloodStock(BloodID),
foreign key (DonorID) references Donor(DonorID)
);
GO

-- Tạo bảng Event (Sự kiện hiến máu)
CREATE TABLE Event (
EventID INT PRIMARY KEY IDENTITY(1,1),
EventName NVARCHAR(100) NOT NULL,
Description NVARCHAR(200) NOT NULL,
Location NVARCHAR(255) NOT NULL,
EventDate DATE NOT NULL,
AmountOfBlood INT NOT NULL,
Status NVARCHAR(20) NOT NULL DEFAULT 'Upcoming', -- Cancelled, Upcoming, Ongoing, Completed
);
GO

-- Tạo bảng đăng ký hiến máu -> lưu thành lịch sử hiến máu
CREATE TABLE Donation (
DonationID int PRIMARY KEY IDENTITY(1,1),
DonorID int NOT NULL,
EventID int NOT NULL,
FOREIGN KEY (DonorID) REFERENCES Donor(DonorID),
FOREIGN KEY (EventID) REFERENCES Event(EventID)
);

-- Tạo bảng BloodRequirement (Yêu cầu máu)
CREATE TABLE BloodRequirement (
	ID INT PRIMARY KEY IDENTITY(1,1),
    RU_ID NCHAR(10) NOT NULL,
    RequestDate DATETIME NOT NULL DEFAULT GETDATE(),
    SupplyDate DATETIME NOT NULL,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Pending', -- Pending, Approved, Completed, Rejected
    FOREIGN KEY (RU_ID) REFERENCES ReceivingUnit(RU_ID)
);
GO

-- Bảng chi tiết yêu cầu máu, vì có thể yêu cầu nhiều loại máu nên phải thêm bảng này 
CREATE TABLE BloodRequirementDetail (
    DetailID INT PRIMARY KEY IDENTITY(1,1),
    RequirementID INT NOT NULL,
    BloodType NVARCHAR(10) NOT NULL,
    Amount FLOAT NOT NULL,
    FOREIGN KEY (RequirementID) REFERENCES BloodRequirement(ID)
);


CREATE TABLE HistoryDonation(
HisDonaID INT PRIMARY KEY IDENTITY(1,1),
DonorID INT NOT NULL,
DonationID INT NULL,
EventID INT NULL,
DonationDate DATETIME NOT NULL DEFAULT GETDATE(),
Weight FLOAT NOT NULL,
BloodPressure NVARCHAR(20) NULL, --Huyết áp
Amount FLOAT NULL, --Lượng máu hiến (ml)
HealthStatus NVARCHAR(50) NOT NULL DEFAULT 'ELigible', --Hợp lệ: Eligible, Không hợp lệ: Not Eligible
Notes NVARCHAR(255) NULL,

FOREIGN KEY (DonorID) REFERENCES Donor(DonorID),
FOREIGN KEY (DonationID) REFERENCES Donation(DonationID),
FOREIGN KEY (EventID) REFERENCES Event(EventID)
);


---- Bảng thông báo
CREATE TABLE Notifications(
NotifiID INT PRIMARY KEY IDENTITY(1,1),
ObjectID NVARCHAR(10) NOT NULL,
Title NVARCHAR(100) NOT NULL,
Message NVARCHAR(100) NOT NULL,
CreateAt DATETIME NOT NULL DEFAULT GETDATE(),
IsRead BIT NOT NULL DEFAULT 1
);


-- SỬ DỤNG CHO LOG IN 
CREATE TABLE UserAccount (
    AccountID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) UNIQUE NOT NULL,
    Password NVARCHAR(255) NOT NULL,
    Role NVARCHAR(20) NOT NULL, -- 'Admin', 'Donor', 'ReceivingUnit'
    ObjectID NVARCHAR(10) NOT NULL -- Tham chiếu tới DonorID hoặc RU_ID
);


-- MỚI THÊM 12/05
CREATE TABLE BloodSupplyDetail (
    SupplyID INT PRIMARY KEY IDENTITY(1,1),
    RequirementDetailID INT NOT NULL,
    BloodDetailID INT NOT NULL,
    Amount FLOAT NOT NULL,
    FOREIGN KEY (RequirementDetailID) REFERENCES BloodRequirementDetail(DetailID),
    FOREIGN KEY (BloodDetailID) REFERENCES BloodDetail(BloodDetailID)
);



-- ============== Dữ liệu bên trong Database ===============
-- 1. Thêm dữ liệu vào bảng Donor
INSERT INTO Donor (FullName, BloodType, BirthDate, PhoneNumber, Address, LastDonationDate, Gender, Email) VALUES
(N'Nguyễn Văn An', 'A+', '1990-05-15', '0912345678', N'123 Nguyễn Huệ, Quận 1, TP.HCM', '2023-10-10', 'Male', 'nguyenvanan@email.com'),
(N'Trần Ngọc Bình', 'B+', '1988-12-20', '0987654321', N'456 Lê Lợi, Quận 3, TP.HCM', '2023-11-12', 'Male', 'tranngocbinh@email.com'),
(N'Phạm Thị Cẩm', 'O-', '1995-03-25', '0909123456', N'789 Võ Văn Tần, Quận 10, TP.HCM', '2023-12-05', 'Female', 'phamthicam@email.com'),
(N'Lê Thúy Diệu', 'AB+', '1992-07-18', '0919876543', N'101 Cách Mạng Tháng 8, Quận 3, TP.HCM', '2024-01-20', 'Female', 'lethuydieu@email.com'),
(N'Hoàng Minh Đức', 'A-', '1985-09-30', '0978123456', N'202 Điện Biên Phủ, Quận Bình Thạnh, TP.HCM', '2024-02-15', 'Male', 'hoangminhduc@email.com'),
(N'Vũ Thảo Giang', 'B-', '1993-11-05', '0967891234', N'303 Xô Viết Nghệ Tĩnh, Quận Bình Thạnh, TP.HCM', NULL, 'Female', 'vuthaogiang@email.com'),
(N'Ngô Hồng Hoa', 'O+', '1991-04-12', '0923456789', N'404 Nguyễn Xí, Quận Bình Thạnh, TP.HCM', '2024-03-01', 'Female', 'ngohonghoa@email.com'),
(N'Bùi Tuấn Kiệt', 'A+', '1987-08-22', '0934567890', N'505 Phan Đăng Lưu, Quận Phú Nhuận, TP.HCM', '2023-09-18', 'Male', 'buituankiet@email.com'),
(N'Đoàn Trang Linh', 'AB-', '1994-02-28', '0945678901', N'606 Hồ Văn Huê, Quận Phú Nhuận, TP.HCM', '2024-01-05', 'Female', 'doantranglinh@email.com'),
(N'Mai Hân Mai', 'O+', '1989-06-15', '0956789012', N'707 Nguyễn Kiệm, Quận Gò Vấp, TP.HCM', '2023-12-12', 'Female', 'maihanmai@email.com'),
-- Nhóm 18-25 tuổi
(N'Lê Thanh Tùng', 'A+', '2000-03-12', '0912345679', N'212 Lý Thường Kiệt, Quận 10, TP.HCM', '2024-03-05', 'Male', 'lethanhtung@email.com'),
(N'Nguyễn Thị Hương', 'B-', '2001-07-25', '0987654322', N'157 Trần Hưng Đạo, Quận 1, TP.HCM', '2024-02-18', 'Female', 'nguyenthihuong@email.com'),
(N'Phan Văn Quân', 'O+', '2003-09-08', '0909123457', N'89 Hai Bà Trưng, Quận 1, TP.HCM', '2024-04-01', 'Male', 'phanvanquan@email.com'),
(N'Trần Thị Ngọc', 'AB+', '2004-11-30', '0919876544', N'321 Nguyễn Đình Chiểu, Quận 3, TP.HCM', NULL, 'Female', 'tranthingoc@email.com'),

-- Nhóm 35-50 tuổi
(N'Vũ Đức Minh', 'A-', '1981-05-17', '0978123457', N'56 Lê Văn Sỹ, Quận Phú Nhuận, TP.HCM', '2023-12-10', 'Male', 'vuducminh@email.com'),
(N'Nguyễn Thị Lan Anh', 'B+', '1978-02-14', '0967891235', N'78 Nguyễn Trãi, Quận 5, TP.HCM', '2024-01-15', 'Female', 'nguyenthilananh@email.com'),
(N'Hoàng Văn Đạt', 'O-', '1975-10-25', '0923456790', N'112 Tôn Đản, Quận 4, TP.HCM', '2023-11-20', 'Male', 'hoangvandat@email.com'),
(N'Phạm Thị Hồng', 'AB-', '1980-08-05', '0934567891', N'245 Nguyễn Thái Học, Quận 1, TP.HCM', '2024-02-28', 'Female', 'phamthihong@email.com'),

-- Nhóm 55-65 tuổi
(N'Lê Văn Hùng', 'A+', '1965-12-01', '0945678902', N'67 Pasteur, Quận 1, TP.HCM', '2023-10-05', 'Male', 'levanhung@email.com'),
(N'Trương Thị Xuân', 'O+', '1960-04-18', '0956789013', N'189 Điện Biên Phủ, Quận 3, TP.HCM', '2024-03-25', 'Female', 'truongthixuan@email.com');



-- 2. Thêm dữ liệu vào bảng ReceivingUnit
INSERT INTO ReceivingUnit (RU_ID, UnitName, ContactName, Address, PhoneNumber, Email, UnitType) VALUES
('BV001', N'Bệnh viện Chợ Rẫy', N'Nguyễn Văn Nam', N'201 Nguyễn Chí Thanh, Quận 5, TP.HCM', '02838554137', 'choray@hospital.com', 'Hospital'),
('BV002', N'Bệnh viện Từ Dũ', N'Trần Thị Hương', N'284 Cống Quỳnh, Quận 1, TP.HCM', '02838394747', 'tudu@hospital.com', 'Hospital'),
('BV003', N'Bệnh viện 115', N'Lê Minh Hải', N'527 Sư Vạn Hạnh, Quận 10, TP.HCM', '02838554137', '115@hospital.com', 'Hospital'),
('PK001', N'Phòng khám Đa khoa Sài Gòn', N'Phạm Thanh Trúc', N'125 Lý Tự Trọng, Quận 1, TP.HCM', '02839251234', 'saigon@clinic.com', 'Clinic'),
('PK002', N'Phòng khám Vinmec Central Park', N'Hoàng Văn Thành', N'208 Nguyễn Hữu Cảnh, Quận Bình Thạnh, TP.HCM', '02836221456', 'vinmec@clinic.com', 'Clinic');

-- 3. Thêm dữ liệu vào bảng BloodStock
INSERT INTO BloodStock (BloodType, Amount) VALUES
('A+', 5000),
('A-', 2000),
('B+', 4500),
('B-', 1800),
('AB+', 1500),
('AB-', 1000),
('O+', 6000),
('O-', 3000);

-- 4. Thêm dữ liệu vào bảng Event
INSERT INTO Event (EventName, Description, Location, EventDate, AmountOfBlood, Status) VALUES
(N'Hiến máu nhân đạo lần 1', N'Sự kiện hiến máu hàng quý tại Đại học Y Dược', N'Trường Đại học Y Dược, 217 Hồng Bàng, Quận 5, TP.HCM', '2023-10-05', 2000, 'Completed'),
(N'Ngày hội hiến máu tình nguyện', N'Chương trình hiến máu nhân đạo hưởng ứng phong trào Chủ nhật đỏ', N'Nhà văn hóa Thanh niên, 4 Phạm Ngọc Thạch, Quận 1, TP.HCM', '2023-11-20', 3000, 'Completed'),
(N'Giọt hồng yêu thương', N'Chương trình hiến máu do Hội Chữ thập đỏ tổ chức', N'Công viên Lê Văn Tám, Quận 1, TP.HCM', '2023-12-15', 2500, 'Completed'),
(N'Hiến máu cứu người - Sinh mệnh của bạn', N'Sự kiện hiến máu tại các trường Đại học', N'Trường Đại học Bách Khoa, 268 Lý Thường Kiệt, Quận 10, TP.HCM', '2024-01-25', 4000, 'Completed'),
(N'Ngày hội hiến máu mùa xuân', N'Chương trình hiến máu đầu năm', N'Bệnh viện Chợ Rẫy, 201 Nguyễn Chí Thanh, Quận 5, TP.HCM', '2024-02-18', 3500, 'Completed'),
(N'Hiến máu nhân đạo lần 2', N'Sự kiện hiến máu tình nguyện quý 2', N'Trường Đại học Khoa học Tự nhiên, 227 Nguyễn Văn Cừ, Quận 5, TP.HCM', '2024-03-10', 3000, 'Completed'),
(N'Hiến máu vì cộng đồng', N'Chương trình hiến máu do các doanh nghiệp phối hợp tổ chức', N'Tòa nhà Bitexco, 2 Hải Triều, Quận 1, TP.HCM', '2024-04-20', 2500, 'Ongoing'),
(N'Hiến máu tình nguyện đợt 3', N'Chương trình hiến máu tình nguyện quý 3', N'Nhà văn hóa Thanh niên, 4 Phạm Ngọc Thạch, Quận 1, TP.HCM', '2024-05-15', 3000, 'Upcoming'),
(N'Giọt máu nghĩa tình', N'Chương trình hiến máu nhân đạo toàn quốc', N'Cung Văn hóa Lao động TP.HCM, 55B Nguyễn Thị Minh Khai, Quận 1, TP.HCM', '2024-06-20', 4000, 'Upcoming'),
(N'Hiến máu cứu người đợt 4', N'Chương trình hiến máu tình nguyện cuối năm', N'Bệnh viện Thống Nhất, 1 Lý Thường Kiệt, Quận Tân Bình, TP.HCM', '2024-07-25', 3500, 'Upcoming');

-- 5. Thêm dữ liệu vào bảng Donation
INSERT INTO Donation (DonorID, EventID) VALUES
(1, 1),
(2, 1),
(3, 2),
(4, 2),
(5, 3),
(1, 4),
(6, 4),
(7, 5),
(8, 5),
(9, 6),
(10, 6),
(2, 7),
(3, 7),
(11, 7),
(12, 7),
(13, 7),
(15, 6),
(16, 6),
(17, 5),
(19, 4),
(20, 3);

-- 6. Thêm dữ liệu vào bảng BloodDetail
INSERT INTO BloodDetail (BloodID, CollectionDate, ExpiredDate, Status, DonorID) VALUES
(1, '2023-10-05 09:30:00', '2023-11-05 09:30:00', 'Used', 1),
(3, '2023-10-05 10:15:00', '2023-11-05 10:15:00', 'Used', 2),
(2, '2023-11-20 09:00:00', '2023-12-20 09:00:00', 'Used', 3),
(6, '2023-11-20 11:30:00', '2023-12-20 11:30:00', 'Used', 4),
(5, '2023-12-15 10:00:00', '2024-01-15 10:00:00', 'Used', 5),
(1, '2024-01-25 09:45:00', '2024-02-25 09:45:00', 'Available', 1),
(4, '2024-01-25 14:00:00', '2024-02-25 14:00:00', 'Available', 6),
(7, '2024-02-18 10:30:00', '2024-03-18 10:30:00', 'Available', 7),
(1, '2024-02-18 11:15:00', '2024-03-18 11:15:00', 'Available', 8),
(8, '2024-03-10 09:15:00', '2024-04-10 09:15:00', 'Available', 9),
(7, '2024-03-10 10:45:00', '2024-04-10 10:45:00', 'Available', 10),
(3, '2024-04-20 09:30:00', '2024-05-20 09:30:00', 'Quarantine', 2),
(2, '2024-04-20 13:00:00', '2024-05-20 13:00:00', 'Quarantine', 3),
(8, '2023-10-12 10:00:00', '2023-11-12 10:00:00', 'Used', NULL), -- O-
(8, '2023-10-12 11:00:00', '2023-11-12 11:00:00', 'Used', NULL), -- O-
(4, '2023-11-08 09:00:00', '2023-12-08 09:00:00', 'Used', NULL),  -- B+
(6, '2023-11-08 10:00:00', '2023-12-08 10:00:00', 'Used', NULL), -- AB-
(1, '2024-04-20 08:30:00', '2024-05-20 08:30:00', 'Quarantine', 11), -- A+ từ người trẻ
(2, '2024-04-20 09:15:00', '2024-05-20 09:15:00', 'Quarantine', 12), -- B- từ người trẻ
(7, '2024-04-20 10:00:00', '2024-05-20 10:00:00', 'Quarantine', 13), -- O+ từ người trẻ
(5, '2024-03-10 11:30:00', '2024-04-10 11:30:00', 'Available', 15), -- A- từ người trung niên
(3, '2024-03-10 13:00:00', '2024-04-10 13:00:00', 'Available', 16), -- B+ từ người trung niên
(8, '2024-02-18 14:15:00', '2024-03-18 14:15:00', 'Used', 17), -- O- từ người trung niên
(1, '2024-01-25 15:30:00', '2024-02-25 15:30:00', 'Used', 19), -- A+ từ người cao tuổi
(7, '2023-12-15 16:00:00', '2024-01-15 16:00:00', 'Used', 20); -- O+ từ người cao tuổi


-- 7. Thêm dữ liệu vào bảng BloodRequirement
INSERT INTO BloodRequirement (RU_ID, RequestDate, SupplyDate, Status) VALUES
('BV001', '2023-10-10', '2023-10-12', 'Completed'),
('BV002', '2023-10-15', '2023-10-18', 'Rejected'),
('BV003', '2023-11-05', '2023-11-08', 'Completed'),
('PK001', '2023-11-20', '2023-11-22', 'Rejected'),
('BV001', '2023-12-10', '2023-12-13', 'Completed'),
('BV002', '2024-01-05', '2024-01-08', 'Approved'),
('BV003', '2024-01-18', '2024-01-20', 'Completed'),
('PK002', '2024-02-05', '2024-02-08', 'Approved'),
('BV001', '2024-02-20', '2024-02-23', 'Completed'),
('BV002', '2024-03-15', '2024-03-18', 'Completed'),
('BV001', '2024-04-05', '2024-04-08', 'Approved'),
('BV003', '2024-04-10', '2024-04-15', 'Pending');

-- 8. Thêm dữ liệu vào bảng HistoryDonation
INSERT INTO HistoryDonation (DonorID, DonationID, EventID, DonationDate, Weight, BloodPressure, Amount, HealthStatus, Notes) VALUES
(1, 1, 1, '2023-10-05 09:30:00', 70.5, '120/80', 350, 'Eligible', N'Sức khỏe tốt, không có vấn đề'),
(2, 2, 1, '2023-10-05 10:15:00', 65.0, '115/75', 350, 'Eligible', N'Sức khỏe tốt, lần hiến đầu tiên'),
(3, 3, 2, '2023-11-20 09:00:00', 58.5, '110/70', 300, 'Eligible', N'Sức khỏe tốt, cần uống nhiều nước sau khi hiến'),
(4, 4, 2, '2023-11-20 11:30:00', 62.0, '125/85', 350, 'Eligible', N'Sức khỏe tốt, không có vấn đề'),
(5, 5, 3, '2023-12-15 10:00:00', 75.5, '130/85', 400, 'Eligible', N'Sức khỏe tốt, huyết áp hơi cao nhưng trong giới hạn cho phép'),
(1, 6, 4, '2024-01-25 09:45:00', 71.0, '118/78', 350, 'Eligible', N'Lần hiến thứ 2, sức khỏe tốt'),
(6, 7, 4, '2024-01-25 14:00:00', 55.0, '105/65', 250, 'Eligible', N'Cân nặng thấp nên chỉ hiến 250ml'),
(7, 8, 5, '2024-02-18 10:30:00', 63.5, '120/80', 350, 'Eligible', N'Sức khỏe tốt, không có vấn đề'),
(8, 9, 5, '2024-02-18 11:15:00', 68.0, '125/82', 350, 'Eligible', N'Sức khỏe tốt, không có vấn đề'),
(9, 10, 6, '2024-03-10 09:15:00', 59.5, '110/70', 300, 'Eligible', N'Sức khỏe tốt, cần uống nhiều nước sau khi hiến'),
(10, 11, 6, '2024-03-10 10:45:00', 67.0, '120/78', 350, 'Eligible', N'Sức khỏe tốt, không có vấn đề'),
(2, 12, 7, '2024-04-20 09:30:00', 66.5, '118/76', 350, 'Eligible', N'Sức khỏe tốt, lần hiến thứ 2'),
(3, 13, 7, '2024-04-20 13:00:00', 59.0, '112/72', 300, 'Eligible', N'Sức khỏe tốt, không có vấn đề'),
(11, NULL, 7, '2024-04-20 08:30:00', 68.5, '120/80', 350, 'Eligible', N'Lần hiến đầu tiên, sức khỏe tốt'),
(12, NULL, 7, '2024-04-20 09:15:00', 55.0, '110/70', 300, 'Eligible', N'Cân nặng hơi thấp nhưng vẫn đủ điều kiện'),
(13, NULL, 7, '2024-04-20 10:00:00', 75.0, '125/85', 400, 'Eligible', N'Sức khỏe tốt, hiến máu lần thứ 2'),
(15, NULL, 6, '2024-03-10 11:30:00', 80.0, '135/90', 350, 'Eligible', N'Huyết áp hơi cao nhưng vẫn trong giới hạn cho phép'),
(16, NULL, 6, '2024-03-10 13:00:00', 65.5, '120/80', 350, 'Eligible', N'Sức khỏe tốt, đã hiến máu thường xuyên'),
(17, NULL, 5, '2024-02-18 14:15:00', 72.0, '118/78', 350, 'Eligible', N'Sức khỏe tốt, không có vấn đề'),
(19, NULL, 4, '2024-01-25 15:30:00', 70.5, '120/75', 350, 'Eligible', N'Sức khỏe tốt, đã hiến máu nhiều lần'),
(20, NULL, 3, '2023-12-15 16:00:00', 68.0, '115/75', 300, 'Eligible', N'Sức khỏe ổn định dù ở tuổi cao');

-- 9. Thêm dữ liệu vào bảng BloodRequirementDetail
INSERT INTO BloodRequirementDetail (RequirementID, BloodType, Amount) VALUES
(1, 'A+', 5000),
(2, 'O-', 3000),
(3, 'B+', 7000),
(4, 'AB-', 20000),
(5, 'O+', 6000),
(6, 'A-', 4000),
(7, 'B-', 30000),
(8, 'AB+', 8000),
(9, 'A+', 5000),
(10, 'O-', 25000);

-- 10. Thêm dữ liệu vào bảng Notifications
INSERT INTO Notifications (ObjectID, Title, Message, CreateAt, IsRead)
VALUES
('BV001', N'Lời nhắc hiến máu', N'Xin chào! Đã đến thời gian hiến máu định kỳ của bạn. Vui lòng đặt lịch hẹn.', GETDATE(), 0),
('BV002', N'Cập nhật quy định mới', N'Chúng tôi có những thay đổi mới về quy trình hiến máu. Vui lòng đọc kỹ thông tin đính kèm.', DATEADD(DAY, -2, GETDATE()), 0),
('BV003', N'Thông báo', N'Sự kiện hiến máu nhân đạo sẽ diễn ra vào ngày 20/05/2025 tại Trung tâm Y tế.', DATEADD(DAY, -5, GETDATE()), 1),
('PK001', N'Thông báo sự kiện', N'Sự kiện hiến máu nhân đạo sẽ diễn ra vào ngày 20/05/2025 tại Trung tâm Y tế.', DATEADD(DAY, -5, GETDATE()), 1),
('PK002', N'Thông báo sự kiện hiến máu', N'Sự kiện hiến máu nhân đạo sẽ diễn ra vào ngày 20/05/2025 tại Trung tâm Y tế.', DATEADD(DAY, -5, GETDATE()), 1);


-- SỬ DỤNG CHO LOG IN
-- Thêm tài khoản cho một Donor
INSERT INTO UserAccount (Username, Password, Role, ObjectID)
VALUES ('donor1', '123456', 'Donor', '1'), 
 ('donor2', '123456', 'Donor', '2'), 
 ('donor3', '123456', 'Donor', '3'),
 ('donor4', '123456', 'Donor', '4'), 
 ('donor5', '123456', 'Donor', '5'), 
 ('donor6', '123456', 'Donor', '6'),
 ('donor7', '123456', 'Donor', '7'), 
 ('donor8', '123456', 'Donor', '8'), 
 ('donor9', '123456', 'Donor', '9'), 
 ('donor10', '123456', 'Donor', '10'),
 ('donor11', '123456', 'Donor', '11'), 
 ('donor12', '123456', 'Donor', '12'), 
 ('donor13', '123456', 'Donor', '13'), 
 ('donor14', '123456', 'Donor', '14'),
 ('donor15', '123456', 'Donor', '15'),
 ('donor16', '123456', 'Donor', '16'),
 ('donor17', '123456', 'Donor', '17'),
 ('donor18', '123456', 'Donor', '18'),
 ('donor19', '123456', 'Donor', '19'),
 ('donor20', '123456', 'Donor', '20');


-- Thêm tài khoản cho một ReceivingUnit
INSERT INTO UserAccount (Username, Password, Role, ObjectID)
VALUES ('hospital1', '123456', 'ReceivingUnit', 'BV001'), 
 ('clinic1', '123456', 'ReceivingUnit', 'PK001'), 
 ('nursinghome1', '123456', 'ReceivingUnit', 'BV003'), 
 ('hospital2', '123456', 'ReceivingUnit', 'BV002'), 
 ('clinic2', '123456', 'ReceivingUnit', 'PK002'); 


-- Thêm tài khoản cho Admin
INSERT INTO UserAccount (Username, Password, Role, ObjectID)
VALUES ('admin', 'admin123', 'Admin', 'Admin'); 


-- MỚI THÊM 12/05 
INSERT INTO BloodSupplyDetail (RequirementDetailID, BloodDetailID, Amount) VALUES
-- Cấp máu A+ cho yêu cầu RequirementDetailID = 1 (5000ml)
(1, 1, 2500),  -- BloodDetailID 1: A+ từ DonorID 1
(1, 6, 2500),  -- BloodDetailID 6: A+ từ DonorID 1

-- Cấp máu O+ cho yêu cầu RequirementDetailID = 5 (6000ml)
(5, 7, 3000),  -- BloodDetailID 7: O+ từ DonorID 7
(5, 11, 3000); -- BloodDetailID 11: O+ từ DonorID 10


--SELECT bd.BloodDetailID, bs.BloodType 
--FROM BloodDetail bd
--JOIN BloodStock bs ON bd.BloodID = bs.BloodID
--WHERE bd.BloodDetailID IN (1, 2, 3, 6, 7, 11, 13);
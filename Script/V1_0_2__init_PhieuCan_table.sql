create table PhieuCan
(
SoPhieu varchar(50) NOT NULL,
Ngay date NOT NULL,
KhachHangID varchar(50) NOT NULL,
SanPhamID varchar(50) NOT NULL,
SoXe varchar(50) NOT NULL,
GioVao time(7) NOT NULL,
GioRa time(7) NULL,
TienVanChuyen float NULL,
TrongLuongVao float NOT NULL,
TrongLuongRa float NOT NULL,
GhiChu nvarchar(500) NULL,
constraint PK_PhieuCan Primary key (SoPhieu, Ngay)
)

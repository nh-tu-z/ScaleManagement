alter table PhieuCan add constraint PhieuCan_KhachHangID_FK
foreign key (KhachHangID) references KhachHang(ID)
GO
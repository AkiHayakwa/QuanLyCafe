drop database QlyCafe

create database QlyCafe

go

use QlyCafe

go

-- Tạo bảng DanhMuc
CREATE TABLE DanhMuc (
    id_DanhMuc INT IDENTITY(1,1) PRIMARY KEY ,
	TenDanhMuc NVARCHAR(100) NOT NULL
);
Drop table DanhMuc;
-- Tạo bảng SanPham
CREATE TABLE SanPham (
    id_SanPham INT PRIMARY KEY ,
    TenSanPham NVARCHAR(100) NOT NULL,
    giaMua DECIMAL(10, 2) NOT NULL,
	SoLuongTon int not null , 
	TrangThai NVARCHAR(50) NOT NULL , 
    id_DanhMuc INT,
    FOREIGN KEY (id_DanhMuc) REFERENCES DanhMuc(id_DanhMuc)
);

-- Tạo bảng BanCafe
CREATE TABLE BanCafe (
    id_Ban INT PRIMARY KEY ,
    TenBan NVARCHAR(100) NOT NULL,
    TrangThai NVARCHAR(50) NOT NULL
);


-- Tạo bảng HoaDon
CREATE TABLE HoaDon (
    id_HoaDon INT PRIMARY KEY,
    id_Ban INT not null,
	id_KhachHang INT not null , 
	Ngay Date ,
    TongTien DECIMAL(10, 2),
    GiamGia DECIMAL(10, 2) not null default 0,

    FOREIGN KEY (id_Ban) REFERENCES BanCafe(id_Ban),
	FOREIGN KEY (id_KhachHang) REFERENCES KhachHang(id_KhachHang)
);

-- Tạo bảng ChiTietHoaDon
CREATE TABLE ChiTietHoaDon (
    id INT PRIMARY KEY ,
    id_HoaDon INT,
    id_SanPham INT,
    SoLuong INT NOT NULL,
	GiaBan Float NOT NULL,
    FOREIGN KEY (id_HoaDon) REFERENCES HoaDon(id_HoaDon),
    FOREIGN KEY (id_SanPham) REFERENCES SanPham(id_SanPham)
);


-- Tạo bảng TaiKhoan
CREATE TABLE TaiKhoan (
    id_TaiKhoan INT IDENTITY(1,1) PRIMARY KEY  ,
    TenNguoiDung NVARCHAR(100) NOT NULL,
    MatKhau NVARCHAR(100) NOT NULL,
    TrangThai NVARCHAR(50),
    Quyen NVARCHAR(100),
);

CREATE TABLE KhachHang(
     id_KhachHang INT PRIMARY KEY , 
	 TENKH NVARCHAR(30) NOT NULL ,
     DT VARCHAR(11) CHECK(DT LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]' 
	                         OR DT LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
							 OR DT LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
							 OR DT LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'
							 OR DT IS NULL) , 
	 EMAIL VARCHAR(30) 
);
select * from NhanVien;
select * from TaiKhoan;
drop table TaiKhoan

select * from SanPham;
insert into TaiKhoan values ('Nguyen Van Tru','123456789',N'Hoạt động','Admin'),('Nguyen Van Thu','123456789',N'Hoạt động','Thu Ngân');


insert into DanhMuc values (N'Cafe'),(N'Bánh Ngọt'),(N'Sinh tố'),(N'Trà sữa')


select * from SanPham;
select * from DanhMuc;
go
CREATE TRIGGER trg_UpdateSanPham
ON SanPham
AFTER UPDATE
AS
BEGIN
    -- Kiểm tra nếu số lượng tồn được cập nhật và bằng 0
    IF EXISTS (SELECT * FROM inserted WHERE SoLuongTon = 0)
    BEGIN
        -- Cập nhật trạng thái sản phẩm thành "Không còn" nếu số lượng tồn = 0
        UPDATE SanPham
        SET TrangThai = 'Không còn'
        FROM SanPham sp
        INNER JOIN inserted i ON sp.id_SanPham = i.id_SanPham
        WHERE i.SoLuongTon = 0;
    END
END

delete from sanpham 
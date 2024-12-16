drop database QlyCafe

create database QlyCafe

go

use QlyCafe

go

-- Tạo bảng DanhMuc
CREATE TABLE DanhMuc (
    id_DanhMuc INT PRIMARY KEY ,
    TenDanhMuc NVARCHAR(100) NOT NULL
);

-- Tạo bảng SanPham
CREATE TABLE SanPham (
    id_SanPham INT PRIMARY KEY ,
    TenSanPham NVARCHAR(100) NOT NULL,
    gia DECIMAL(10, 2) NOT NULL,
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
    id_Ban INT,
    id_NhanVien INT,
    TongTien DECIMAL(10, 2),
    GiamGia DECIMAL(10, 2),
    FOREIGN KEY (id_Ban) REFERENCES BanCafe(id_Ban),
    FOREIGN KEY (id_NhanVien) REFERENCES NhanVien(id_NhanVien)
);

-- Tạo bảng ChiTietHoaDon
CREATE TABLE ChiTietHoaDon (
    id INT PRIMARY KEY ,
    id_HoaDon INT,
    id_SanPham INT,
    SoLuong INT NOT NULL,
    FOREIGN KEY (id_HoaDon) REFERENCES HoaDon(id_HoaDon),
    FOREIGN KEY (id_SanPham) REFERENCES SanPham(id_SanPham)
);

-- Tạo bảng NhanVien
CREATE TABLE NhanVien (
    id_NhanVien INT PRIMARY KEY ,
    TenNhanVien NVARCHAR(100) NOT NULL,
    sodienthoai NVARCHAR(20),
    email NVARCHAR(100)
);

-- Tạo bảng TaiKhoan
CREATE TABLE TaiKhoan (
    id_TaiKhoan INT IDENTITY(1,1) PRIMARY KEY  ,
    TenNguoiDung NVARCHAR(100) NOT NULL,
    MatKhau NVARCHAR(100) NOT NULL,
    TrangThai NVARCHAR(50),
    Quyen NVARCHAR(100),
);
select * from NhanVien;
select * from TaiKhoan;
drop table TaiKhoan


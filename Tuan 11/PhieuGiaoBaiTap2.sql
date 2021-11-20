use master

create database QLBanHang

use QLBanHang

create table KhachHang(
    MaKH char(4) primary key,
    TenKH nvarchar(50),
    SoDT varchar(12),
    DiaChi nvarchar(50)
)

create table HoaDon (
    MaHD nchar(4) primary key,
    NgayLap date,
    NguoiLap varchar(10),
    MaKH char(4),

    constraint FK_MaKH foreign key(MaKH) references KhachHang(MaKH)
)

create table LoaiSanPham(
    MaLoai char(3) primary key,
    TenLoai nvarchar(50) not null
)

create table SanPham(
    MaSP char(4) primary key,
    TenSP nvarchar(50) not null,
    MaLoai char(3),
    SoLuong int,
    DonGia int

    constraint FK_MaLoai foreign key(MaLoai) references LoaiSanPham(MaLoai)
)

create table NguoiDung(
    TenDangNhap varchar(10) primary key,
    MatKhau varchar(10) not null,
    HoTen nvarchar(50) not null
)

create table HoaDon_ChiTiet(
    MaHD nchar(4),
    MaSP char(4),
    SoLuongMua int

    constraint FK_MaHD_1 foreign key(MaHD) references HoaDon(MaHD),
    constraint FK_MaSP_1 foreign key(MaSP) references SanPham(MaSP),
    constraint PK_MaHD_MaSP primary key(MaHD, MaSP)
)

-- drop table HoaDon_ChiTiet
-- drop table SanPham
-- drop table HoaDon
-- drop table KhachHang
-- drop table LoaiSanPham
-- drop table NguoiDung

insert into KhachHang values
('KH01', 'Minh', '0123456787', 'Thanh Hoa'),
('KH02', 'Manh', '0123456788', 'Ha Noi'),
('KH03', 'Viet', '0123456789', 'Thai Nguyen')

--select * from KhachHang

insert into HoaDon values
('HD01', '2021-11-17', 'NV01', 'KH01'),
('HD02', '2021-8-23', 'NV02', 'KH02'),
('HD03', '2021-4-19', 'NV03', 'KH01')

-- select * from HoaDon

insert into LoaiSanPham values
('L01', 'Loai 1'),
('L02', 'Loai 2'),
('L03', 'Loai 3')

-- select * from LoaiSanPham

insert into NguoiDung values
('minh01', '123456789', 'Minh'), 
('manh02', '123456789', 'Manh'), 
('viet03', '123456789', 'Viet') 

-- select * from NguoiDung

insert into SanPham values
('SP01', 'San Pham 1', 'L01', 10, 100000),
('SP02', 'San Pham 2', 'L02', 8, 150000),
('SP03', 'San Pham 3', 'L03', 15, 120000)

-- select * from SanPham

insert into HoaDon_ChiTiet values
('HD01', 'SP01', 10),
('HD01', 'SP02', 5),
('HD02', 'SP01', 10)

-- select * from HoaDon_ChiTiet
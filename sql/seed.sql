-- Một số mức lương mẫu
INSERT INTO MucLuong(Nhan, MinLuong, MaxLuong, ThuTu)
VALUES
 (N'< 7 triệu', NULL, 7000000, 1),
 (N'7 - 10 triệu', 7000000, 10000000, 2),
 (N'10 - 15 triệu', 10000000, 15000000, 3),
 (N'>= 15 triệu', 15000000, NULL, 4);


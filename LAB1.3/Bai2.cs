using System;
using System.Collections.Generic;

namespace LAB03
{
    // Lớp TaiLieu có các thuộc tính chung
    internal class TaiLieu
    {
        public string MaTaiLieu { get; set; } = string.Empty;
        public string TenNhaXuatBan { get; set; } = string.Empty;
        public int SoBanPhatHanh { get; set; }

        public virtual void Nhap()
        {
            Console.Write("Nhap ma tai lieu: ");
            MaTaiLieu = Console.ReadLine() ?? string.Empty;
            Console.Write("Nhap ten nha xuat ban: ");
            TenNhaXuatBan = Console.ReadLine() ?? string.Empty;
            Console.Write("Nhap so ban phat hanh: ");
            SoBanPhatHanh = int.Parse(Console.ReadLine() ?? "0");
        }

        public virtual void HienThi()
        {
            Console.WriteLine("Ma tai lieu: " + MaTaiLieu);
            Console.WriteLine("Ten nha xuat ban: " + TenNhaXuatBan);
            Console.WriteLine("So ban phat hanh: " + SoBanPhatHanh);
        }

        public virtual string GetLoai() => "";
    }

    // Lớp Sach: thêm thuộc tính TenTacGia, SoTrang
    internal class Sach : TaiLieu
    {
        public string TenTacGia { get; set; } = string.Empty;
        public int SoTrang { get; set; }

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap ten tac gia: ");
            TenTacGia = Console.ReadLine() ?? string.Empty;
            Console.Write("Nhap so trang: ");
            SoTrang = int.Parse(Console.ReadLine() ?? "0");
        }

        public override void HienThi()
        {
            Console.WriteLine("Loai: Sach");
            base.HienThi();
            Console.WriteLine("Ten tac gia: " + TenTacGia);
            Console.WriteLine("So trang: " + SoTrang);
        }

        public override string GetLoai() => "Sach";
    }

    // Lớp TapChi: thêm thuộc tính SoPhatHanh, ThangPhatHanh
    internal class TapChi : TaiLieu
    {
        public int SoPhatHanh { get; set; }
        public string ThangPhatHanh { get; set; } = string.Empty;

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap so phat hanh: ");
            SoPhatHanh = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhap thang phat hanh: ");
            ThangPhatHanh = Console.ReadLine() ?? string.Empty;
        }

        public override void HienThi()
        {
            Console.WriteLine("Loai: Tap Chi");
            base.HienThi();
            Console.WriteLine("So phat hanh: " + SoPhatHanh);
            Console.WriteLine("Thang phat hanh: " + ThangPhatHanh);
        }

        public override string GetLoai() => "TapChi";
    }

    // Lớp Bao: thêm thuộc tính NgayPhatHanh
    internal class Bao : TaiLieu
    {
        public string NgayPhatHanh { get; set; } = string.Empty;

        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap ngay phat hanh: ");
            NgayPhatHanh = Console.ReadLine() ?? string.Empty;
        }

        public override void HienThi()
        {
            Console.WriteLine("Loai: Bao");
            base.HienThi();
            Console.WriteLine("Ngay phat hanh: " + NgayPhatHanh);
        }

        public override string GetLoai() => "Bao";
    }

    // Lớp QuanLyTaiLieu: quản lý danh sách và các chức năng của tài liệu
    internal class QuanLyTaiLieu
    {
        private List<TaiLieu> dsTaiLieu = new List<TaiLieu>();

        public void NhapTaiLieu()
        {
            Console.WriteLine("Chon loai tai lieu can nhap:");
            Console.WriteLine("1. Sach");
            Console.WriteLine("2. Tap Chi");
            Console.WriteLine("3. Bao");
            Console.Write("Nhap lua chon: ");
            int luaChon = int.Parse(Console.ReadLine() ?? "0");
            TaiLieu tl = luaChon switch
            {
                1 => new Sach(),
                2 => new TapChi(),
                3 => new Bao(),
                _ => null
            };

            if (tl == null)
            {
                Console.WriteLine("Lua chon khong hop le.");
                return;
            }

            tl.Nhap();
            dsTaiLieu.Add(tl);
        }

        public void HienThiTaiLieu()
        {
            if (dsTaiLieu.Count == 0)
            {
                Console.WriteLine("Danh sach trong!");
                return;
            }

            foreach (var tl in dsTaiLieu)
            {
                tl.HienThi();
                Console.WriteLine("-----");
            }
        }

        public void TimKiemTheoLoai()
        {
            Console.Write("Nhap loai tai lieu can tim (Sach, TapChi, Bao): ");
            string loai = Console.ReadLine() ?? string.Empty;

            bool found = false;
            foreach (var tl in dsTaiLieu)
            {
                if (tl.GetLoai().Equals(loai, StringComparison.OrdinalIgnoreCase))
                {
                    tl.HienThi();
                    Console.WriteLine("-----");
                    found = true;
                }
            }
            if (!found)
                Console.WriteLine("Khong tim thay tai lieu loai: " + loai);
        }

        public void Menu()
        {
            int luaChon = -1;
            do
            {
                Console.WriteLine("\nCHUONG TRINH QUAN LY TAI LIEU");
                Console.WriteLine("1. Nhap thong tin tai lieu");
                Console.WriteLine("2. Hien thi danh sach tai lieu");
                Console.WriteLine("3. Tim kiem theo loai tai lieu");
                Console.WriteLine("4. Thoat chuong trinh");
                Console.Write("Chon chuc nang: ");
                luaChon = int.Parse(Console.ReadLine() ?? "0");
                switch (luaChon)
                {
                    case 1:
                        NhapTaiLieu();
                        break;
                    case 2:
                        HienThiTaiLieu();
                        break;
                    case 3:
                        TimKiemTheoLoai();
                        break;
                    case 4:
                        Console.WriteLine("Thoat chuong trinh Bai 2.");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le.");
                        break;
                }
                if (luaChon != 4)
                {
                    Console.WriteLine("Nhan phim bat ky de tiep tuc...");
                    Console.ReadKey();
                }
            } while (luaChon != 4);
        }
    }

    // Lớp tĩnh Bai2 chứa hàm giao diện của bài 2, sẽ được gọi từ file main
    internal static class Bai2
    {
        public static void B2()
        {
            Console.Clear();
            Console.WriteLine("------ Bai 2: Quan ly tai lieu ------");
            QuanLyTaiLieu ql = new QuanLyTaiLieu();
            ql.Menu();
        }
    }
}

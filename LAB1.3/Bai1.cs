using System;
using System.Collections.Generic;

namespace LAB03
{
    // Lớp cơ sở: CanBo
    internal class CanBo
    {
        public string HoTen { get; set; } = string.Empty;
        public int NamSinh { get; set; }
        public string GioiTinh { get; set; } = string.Empty;
        public string DiaChi { get; set; } = string.Empty;

        public virtual void NhapThongTin()
        {
            Console.Write("Nhap ho ten: ");
            HoTen = Console.ReadLine() ?? string.Empty;
            Console.Write("Nhap nam sinh: ");
            NamSinh = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Nhap gioi tinh: ");
            GioiTinh = Console.ReadLine() ?? string.Empty;
            Console.Write("Nhap dia chi: ");
            DiaChi = Console.ReadLine() ?? string.Empty;
        }

        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"Ho ten: {HoTen}, Nam sinh: {NamSinh}, Gioi tinh: {GioiTinh}, Dia chi: {DiaChi}");
        }
    }

    // Lớp NhanVien: kế thừa từ CanBo, thêm thuộc tính công việc
    internal class NhanVien : CanBo
    {
        public string CongViec { get; set; } = string.Empty;

        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.Write("Nhap cong viec: ");
            CongViec = Console.ReadLine() ?? string.Empty;
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Cong viec: {CongViec}");
        }
    }

    // Lớp KySu: kế thừa từ CanBo, thêm thuộc tính ngành đào tạo
    internal class KySu : CanBo
    {
        public string Nganh { get; set; } = string.Empty;

        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.Write("Nhap nganh dao tao: ");
            Nganh = Console.ReadLine() ?? string.Empty;
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Nganh dao tao: {Nganh}");
        }
    }

    // Lớp CongNhan: kế thừa từ CanBo, thêm thuộc tính bậc chu công nhân
    internal class CongNhan : CanBo
    {
        public string Bac { get; set; } = string.Empty;

        public override void NhapThongTin()
        {
            base.NhapThongTin();
            Console.Write("Nhap bac (Vi du: 3/7): ");
            Bac = Console.ReadLine() ?? string.Empty;
        }

        public override void HienThiThongTin()
        {
            base.HienThiThongTin();
            Console.WriteLine($"Bac: {Bac}");
        }
    }

    // Lớp QLCB: Quản lý các cán bộ
    internal class QLCB
    {
        private List<CanBo> danhSachCanBo = new List<CanBo>();

        public void NhapThongTinMoi()
        {
            Console.WriteLine("Nhap loai can bo (1: Nhan Vien, 2: Ky Su, 3: Cong Nhan): ");
            if (!int.TryParse(Console.ReadLine(), out int loaiCanBo))
            {
                Console.WriteLine("Loai can bo khong hop le.");
                return;
            }

            CanBo canBo = loaiCanBo switch
            {
                1 => new NhanVien(),
                2 => new KySu(),
                3 => new CongNhan(),
                _ => throw new ArgumentException("Loai can bo khong hop le")
            };

            canBo.NhapThongTin();
            danhSachCanBo.Add(canBo);
        }

        public void TimKiemTheoHoTen(string hoTen)
        {
            var ketQua = danhSachCanBo.FindAll(cb =>
                cb.HoTen.IndexOf(hoTen, StringComparison.OrdinalIgnoreCase) >= 0);

            if (ketQua.Count == 0)
            {
                Console.WriteLine("Khong tim thay can bo co ho ten: " + hoTen);
                return;
            }

            foreach (var canBo in ketQua)
            {
                canBo.HienThiThongTin();
            }
        }

        public void HienThiDanhSach()
        {
            if (danhSachCanBo.Count == 0)
            {
                Console.WriteLine("Danh sach trong!");
                return;
            }

            foreach (var canBo in danhSachCanBo)
            {
                canBo.HienThiThongTin();
            }
        }

        public void Menu()
        {
            int luaChon = -1;
            do
            {
                Console.WriteLine("\nCHUONG TRINH QUAN LY CAN BO");
                Console.WriteLine("1. Nhap thong tin moi");
                Console.WriteLine("2. Tim kiem theo ho ten");
                Console.WriteLine("3. Hien thi danh sach");
                Console.WriteLine("4. Thoat");
                Console.Write("Chon chuc nang: ");
                int.TryParse(Console.ReadLine(), out luaChon);
                switch (luaChon)
                {
                    case 1:
                        NhapThongTinMoi();
                        break;
                    case 2:
                        Console.Write("Nhap ho ten can tim: ");
                        string name = Console.ReadLine() ?? string.Empty;
                        TimKiemTheoHoTen(name);
                        break;
                    case 3:
                        HienThiDanhSach();
                        break;
                    case 4:
                        Console.WriteLine("Thoat chuong trinh Bai 1.");
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

    // Lớp tĩnh Bai1 chứa hàm xử lý giao diện riêng, được gọi từ file Program.cs
    internal static class Bai1
    {
        public static void B1()
        {
            Console.Clear();
            Console.WriteLine("------ Bai 1: Quan ly can bo ------");
            QLCB ql = new QLCB();
            ql.Menu();
        }
    }
}

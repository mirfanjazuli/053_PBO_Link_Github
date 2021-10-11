using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommissionEmployee
{
    public class KomisiKaryawan
    {
        public string NamaDepan;
        public string NamaBelakang;
        public string NIK;
        private decimal penjualanKotor;
        private decimal tingkatKomisi;

        // konstruktor lima parameter
        public KomisiKaryawan(string namaDepan, string namaBelakang, string nIK, decimal penjualanKotor, decimal tingkatKomisi)
        {
            // panggilan implisit ke konstruktor objek terjadi di sini
            NamaDepan = namaDepan;
            NamaBelakang = namaBelakang;
            NIK = nIK;
            PenjualanKotor = penjualanKotor; // memvalidasi penjualan kotor
            TingkatKomisi = tingkatKomisi; // memvalidasi tingkat komisi
        }
        public void setNamaDepan(string namaDepan)
        {
            NamaDepan = namaDepan;
        }
        public string getNamaDepan()
        {
            return NamaDepan;
        }
        public void setNamaBelakang(string namaBelakang)
        {
            NamaBelakang = namaBelakang;
        }
        public string getNamaBelakang()
        {
            return NamaBelakang;
        }
        public void setNIK(string nIK)
        {
            NIK = nIK;
        }
        public string getNIK()
        {
            return NIK;
        }
        // properti yang mendapatkan dan menetapkan komisi penjualan kotor karyawan
        public decimal PenjualanKotor
        {
            get
            {
                return penjualanKotor;
            }
            set
            {
                penjualanKotor = (value < 0) ? 0 : value; // memvalidasi
            }
        }
        // properti yang mendapatkan dan menetapkan tingkat komisi komisi karyawan
        public decimal TingkatKomisi
        {
            get
            {
                return tingkatKomisi;
            }
            set
            {
                tingkatKomisi = (value > 0 && value < 1) ? value : 0; // memvalidasi
            }
        }
        // menghitung komisi gaji pegawai
        public decimal Pendapatan()
        {
            return tingkatKomisi * penjualanKotor;
        }
        // mengembalikan representasi string dari objek KomisiKaryawan
        public override string ToString()
        {
            return string.Format("Komisi Karyawan : {0} {1} \nNIK \t\t: {2} \nPenjualan Kotor : {3:C} \nTingkat Komisi \t: {4}", NamaDepan, NamaBelakang, NIK, penjualanKotor, tingkatKomisi);
        }
        public class KomisiTambahanKaryawan : KomisiKaryawan
        {
            private decimal gajiPokok;

            public KomisiTambahanKaryawan(string namaDepan, string namaBelakang, string nIK, decimal penjualanKotor, decimal tingkatKomisi, decimal gajiPokok)
                : base(namaDepan, namaBelakang, nIK, penjualanKotor, tingkatKomisi)
            {
                GajiPokok = gajiPokok;
            }
            public decimal GajiPokok
            {
                get
                {
                    return gajiPokok;
                }
                set
                {
                    gajiPokok = (value < 0) ? 0 : value;
                }
            }
            public decimal Pendapatan()
            {
                return tingkatKomisi * penjualanKotor;
            }
        }
        // Menguji kelas KomisiKaryawan
        static void Main(string[] args)
        {
            // membuat instance objek KomisiKaryawan
            KomisiKaryawan karyawan = new KomisiKaryawan("Sue", "Jones", "222-22-222", 10000.00M, .06M);
            // menampilkan data KomisiKaryawan
            Console.WriteLine("Informasi karyawan diperoleh dengan properti dan metode : \n");
            Console.WriteLine("Nama depannya adalah {0}", karyawan.NamaDepan);
            Console.WriteLine("Nama belakangnya adalah {0}", karyawan.NamaBelakang);
            Console.WriteLine("NIKnya adalah {0}", karyawan.NIK);
            Console.WriteLine("Penjualan kotornya adalah {0:C}", karyawan.PenjualanKotor);
            Console.WriteLine("Tingkat komisinya adalah {0:F2}", karyawan.TingkatKomisi);
            Console.WriteLine("Pendapatanya adalah {0:C}", karyawan.Pendapatan());

            karyawan.PenjualanKotor = 5000.00M; // menetapkan penjualan kotor
            karyawan.TingkatKomisi = .1M; // menetapkan tingkat  komisi
            Console.WriteLine("\n{0}:\n\n{1}", "Informasi karyawan yang diperbarui diperoleh dari ToString ", karyawan);
            Console.WriteLine("Pendapatan \t: {0:C}", karyawan.Pendapatan());
            Console.ReadLine();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace QuizUygulamasi
{
    public partial class Form1 : Form
    {
        private struct Soru
        {
            public string Metin;
            public string[] Secenekler;
            public int DogruIndex;
        }

        private readonly List<Soru> sorular = new List<Soru>
        {
            new Soru {
                Metin = "C# dilinde değişken tanımlamak için kullanılan anahtar kelime hangisidir?",
                Secenekler = new[] { "var", "let", "dim", "define" },
                DogruIndex = 0
            },
            new Soru {
                Metin = "Windows Forms'ta bir butona tıklandığında hangi olay tetiklenir?",
                Secenekler = new[] { "MouseEnter", "Click", "Load", "KeyPress" },
                DogruIndex = 1
            },
            new Soru {
                Metin = "Aşağıdakilerden hangisi bir döngü yapısı DEĞİLDİR?",
                Secenekler = new[] { "for", "while", "foreach", "switch" },
                DogruIndex = 3
            },
            new Soru {
                Metin = "C#'ta bir sınıf tanımlamak için kullanılan anahtar kelime nedir?",
                Secenekler = new[] { "struct", "class", "object", "type" },
                DogruIndex = 1
            },
            new Soru {
                Metin = "List<T> hangi namespace içinde yer alır?",
                Secenekler = new[] { "System.IO", "System.Text", "System.Collections.Generic", "System.Linq" },
                DogruIndex = 2
            },
            new Soru {
                Metin = "Bir metodun değer döndürmeyeceğini belirtmek için hangi anahtar kelime kullanılır?",
                Secenekler = new[] { "null", "void", "return", "static" },
                DogruIndex = 1
            },
            new Soru {
                Metin = "String bir değişkenin uzunluğunu öğrenmek için hangi özellik kullanılır?",
                Secenekler = new[] { "Size", "Count", "Length", "Width" },
                DogruIndex = 2
            },
            new Soru {
                Metin = "try-catch bloğu ne amaçla kullanılır?",
                Secenekler = new[] { "Döngü oluşturmak", "Hataları yakalamak", "Değişken tanımlamak", "Metod çağırmak" },
                DogruIndex = 1
            },
            new Soru {
                Metin = "Aşağıdakilerden hangisi bir erişim belirleyici DEĞİLDİR?",
                Secenekler = new[] { "public", "private", "protected", "virtual" },
                DogruIndex = 3
            },
            new Soru {
                Metin = "C#'ta tam sayı türünü temsil eden veri tipi hangisidir?",
                Secenekler = new[] { "float", "double", "int", "char" },
                DogruIndex = 2
            },
            new Soru {
                Metin = "Nesne yönelimli programlamada kalıtımı sağlayan kavram hangisidir?",
                Secenekler = new[] { "Encapsulation", "Polymorphism", "Inheritance", "Abstraction" },
                DogruIndex = 2
            },
            new Soru {
                Metin = "C#'ta bir dizinin eleman sayısını öğrenmek için hangi özellik kullanılır?",
                Secenekler = new[] { "Length", "Size", "Count", "Capacity" },
                DogruIndex = 0
            },
            new Soru {
                Metin = "Aşağıdakilerden hangisi C#'ta geçerli bir yorum satırı değildir?",
                Secenekler = new[] { "// yorum", "/* yorum */", "# yorum", "/// yorum" },
                DogruIndex = 2
            },
            new Soru {
                Metin = "Windows Forms'ta form yüklendiğinde hangi olay tetiklenir?",
                Secenekler = new[] { "Shown", "Activated", "Load", "Paint" },
                DogruIndex = 2
            },
            new Soru {
                Metin = "C#'ta iki string birleştirmek için hangi operatör kullanılır?",
                Secenekler = new[] { "&", "+", ".", "*" },
                DogruIndex = 1
            },
            new Soru {
                Metin = "Aşağıdaki veri tiplerinden hangisi ondalıklı sayıları en hassas şekilde tutar?",
                Secenekler = new[] { "float", "double", "decimal", "int" },
                DogruIndex = 2
            },
            new Soru {
                Metin = "C#'ta bir metodun aynı isimle farklı parametrelerle tanımlanmasına ne denir?",
                Secenekler = new[] { "Overriding", "Overloading", "Inheritance", "Encapsulation" },
                DogruIndex = 1
            },
            new Soru {
                Metin = "Label bileşeninde metni değiştirmek için hangi özellik kullanılır?",
                Secenekler = new[] { "Value", "Caption", "Text", "Content" },
                DogruIndex = 2
            },
            new Soru {
                Metin = "C#'ta 'bool' veri tipi kaç farklı değer alabilir?",
                Secenekler = new[] { "1", "2", "3", "4" },
                DogruIndex = 1
            },
            new Soru {
                Metin = "Aşağıdakilerden hangisi Windows Forms bileşeni DEĞİLDİR?",
                Secenekler = new[] { "TextBox", "ComboBox", "ArrayList", "ListBox" },
                DogruIndex = 2
            }
        };

        private readonly Color RenkMavi = Color.FromArgb(37, 99, 235);
        private readonly Color RenkMaviAcik = Color.FromArgb(219, 234, 254);
        private readonly Color RenkYesil = Color.FromArgb(22, 163, 74);
        private readonly Color RenkYesilAcik = Color.FromArgb(220, 252, 231);
        private readonly Color RenkKirmizi = Color.FromArgb(220, 38, 38);
        private readonly Color RenkKirmiziAcik = Color.FromArgb(254, 226, 226);
        private readonly Color RenkArka = Color.FromArgb(248, 250, 252);
        private readonly Color RenkKart = Color.White;
        private readonly Color RenkMetin = Color.FromArgb(15, 23, 42);
        private readonly Color RenkIkincil = Color.FromArgb(100, 116, 139);
        private readonly Color RenkSinir = Color.FromArgb(226, 232, 240);

        private int mevcutIndex = 0;
        private int dogruSayisi = 0;
        private int yanlisSayisi = 0;
        private bool cevapVerildi = false;

        private Panel pnlUst;
        private Label lblBaslik;
        private Label lblIlerleme;
        private Panel pnlIlerlemeArka;
        private Panel pnlIlerlemeDolu;
        private Panel pnlSoruKart;
        private Label lblSoruNo;
        private Label lblSoruMetni;
        private Panel[] pnlSecimler = new Panel[4];
        private Label[] lblHarfler = new Label[4];
        private Label[] lblSecimler = new Label[4];
        private Label lblGeri;
        private Label lblDogru;
        private Label lblYanlis;
        private Button btnSonraki;

        public Form1()
        {
            InitializeComponent();
            ArayuzOlustur();
            SoruYukle();
        }

        private GraphicsPath YuvarlatilmisYol(Rectangle r, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(r.X, r.Y, radius * 2, radius * 2, 180, 90);
            path.AddArc(r.Right - radius * 2, r.Y, radius * 2, radius * 2, 270, 90);
            path.AddArc(r.Right - radius * 2, r.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(r.X, r.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void ArayuzOlustur()
        {
            this.Text = "Quiz Uygulaması";
            this.Size = new Size(700, 640);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = RenkArka;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Font = new Font("Segoe UI", 10f);

            // Üst şerit
            pnlUst = new Panel { Dock = DockStyle.Top, Height = 64, BackColor = RenkMavi };

            lblBaslik = new Label
            {
                Text = "Quiz Uygulaması",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 13f, FontStyle.Bold),
                Location = new Point(24, 0),
                Size = new Size(280, 64),
                TextAlign = ContentAlignment.MiddleLeft
            };

            lblIlerleme = new Label
            {
                ForeColor = Color.FromArgb(186, 213, 251),
                Font = new Font("Segoe UI", 10f),
                Location = new Point(430, 0),
                Size = new Size(240, 64),
                TextAlign = ContentAlignment.MiddleRight
            };

            pnlUst.Controls.Add(lblBaslik);
            pnlUst.Controls.Add(lblIlerleme);
            this.Controls.Add(pnlUst);

            // İlerleme çubuğu
            pnlIlerlemeArka = new Panel
            {
                Location = new Point(0, 58),
                Size = new Size(700, 6),
                BackColor = Color.FromArgb(147, 197, 253)
            };
            pnlIlerlemeDolu = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(0, 6),
                BackColor = Color.White
            };
            pnlIlerlemeArka.Controls.Add(pnlIlerlemeDolu);
            pnlUst.Controls.Add(pnlIlerlemeArka);

            // Skor satırı
            lblDogru = new Label
            {
                Text = "✔  Doğru: 0",
                ForeColor = RenkYesil,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Location = new Point(24, 80),
                Size = new Size(180, 36),
                TextAlign = ContentAlignment.MiddleLeft
            };
            lblYanlis = new Label
            {
                Text = "✘  Yanlış: 0",
                ForeColor = RenkKirmizi,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Location = new Point(210, 80),
                Size = new Size(180, 36),
                TextAlign = ContentAlignment.MiddleLeft
            };
            this.Controls.Add(lblDogru);
            this.Controls.Add(lblYanlis);

            // Soru kartı
            pnlSoruKart = new Panel
            {
                Location = new Point(24, 126),
                Size = new Size(652, 108),
                BackColor = RenkKart
            };
            pnlSoruKart.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var path = YuvarlatilmisYol(new Rectangle(0, 0, pnlSoruKart.Width - 1, pnlSoruKart.Height - 1), 10))
                using (var pen = new Pen(RenkSinir, 1.5f))
                    e.Graphics.DrawPath(pen, path);
            };

            lblSoruNo = new Label
            {
                Location = new Point(20, 12),
                Size = new Size(612, 18),
                Font = new Font("Segoe UI", 9f),
                ForeColor = RenkIkincil,
                AutoSize = false
            };
            lblSoruMetni = new Label
            {
                Location = new Point(20, 34),
                Size = new Size(612, 62),
                Font = new Font("Segoe UI", 11f),
                ForeColor = RenkMetin,
                AutoSize = false
            };
            pnlSoruKart.Controls.Add(lblSoruNo);
            pnlSoruKart.Controls.Add(lblSoruMetni);
            this.Controls.Add(pnlSoruKart);

            // Şık panelleri
            string[] harfler = { "A", "B", "C", "D" };
            for (int i = 0; i < 4; i++)
            {
                pnlSecimler[i] = new Panel
                {
                    Location = new Point(24, 248 + i * 64),
                    Size = new Size(652, 54),
                    BackColor = RenkKart,
                    Cursor = Cursors.Hand
                };

                pnlSecimler[i].Paint += (s, e) =>
                {
                    Panel p = (Panel)s;
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    Color sinirRenk = p.BackColor == RenkMaviAcik ? RenkMavi
                                    : p.BackColor == RenkYesilAcik ? RenkYesil
                                    : p.BackColor == RenkKirmiziAcik ? RenkKirmizi
                                    : RenkSinir;
                    using (var path = YuvarlatilmisYol(new Rectangle(0, 0, p.Width - 1, p.Height - 1), 10))
                    {
                        e.Graphics.FillPath(new SolidBrush(p.BackColor), path);
                        using (var pen = new Pen(sinirRenk, 1.5f))
                            e.Graphics.DrawPath(pen, path);
                    }
                };

                lblHarfler[i] = new Label
                {
                    Text = harfler[i],
                    Location = new Point(14, 0),
                    Size = new Size(34, 54),
                    Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                    ForeColor = RenkMavi,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                lblSecimler[i] = new Label
                {
                    Location = new Point(54, 0),
                    Size = new Size(584, 54),
                    Font = new Font("Segoe UI", 10f),
                    ForeColor = RenkMetin,
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = false
                };

                pnlSecimler[i].Controls.Add(lblHarfler[i]);
                pnlSecimler[i].Controls.Add(lblSecimler[i]);

                foreach (Control c in new Control[] { pnlSecimler[i], lblHarfler[i], lblSecimler[i] })
                {
                    c.Click += Secim_Click;
                    c.MouseEnter += Secim_MouseEnter;
                    c.MouseLeave += Secim_MouseLeave;
                }

                this.Controls.Add(pnlSecimler[i]);
            }

            // Geri bildirim
            lblGeri = new Label
            {
                Location = new Point(24, 514),
                Size = new Size(652, 28),
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = false
            };
            this.Controls.Add(lblGeri);

            // Sonraki butonu
            btnSonraki = new Button
            {
                Text = "Sonraki Soru  →",
                Location = new Point(502, 555),
                Size = new Size(174, 46),
                BackColor = RenkMavi,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Enabled = false
            };
            btnSonraki.FlatAppearance.BorderSize = 0;
            btnSonraki.Click += BtnSonraki_Click;
            this.Controls.Add(btnSonraki);
        }

        private Panel PaneliBul(Control c)
        {
            if (c is Panel p) return p;
            return c.Parent as Panel;
        }

        private void Secim_MouseEnter(object sender, EventArgs e)
        {
            if (cevapVerildi) return;
            Panel p = PaneliBul((Control)sender);
            if (p != null && p.BackColor == RenkKart) { p.BackColor = RenkMaviAcik; p.Invalidate(); }
        }

        private void Secim_MouseLeave(object sender, EventArgs e)
        {
            if (cevapVerildi) return;
            Panel p = PaneliBul((Control)sender);
            if (p != null && p.BackColor == RenkMaviAcik) { p.BackColor = RenkKart; p.Invalidate(); }
        }

        private void Secim_Click(object sender, EventArgs e)
        {
            if (cevapVerildi) return;

            Panel secilen = PaneliBul((Control)sender);
            if (secilen == null) return;

            int secilenIdx = -1;
            for (int i = 0; i < 4; i++)
                if (pnlSecimler[i] == secilen) { secilenIdx = i; break; }
            if (secilenIdx == -1) return;

            cevapVerildi = true;
            btnSonraki.Enabled = true;

            int dogru = sorular[mevcutIndex].DogruIndex;

            for (int i = 0; i < 4; i++)
            {
                pnlSecimler[i].Cursor = Cursors.Default;
                if (i == dogru)
                {
                    pnlSecimler[i].BackColor = RenkYesilAcik;
                    lblHarfler[i].ForeColor = RenkYesil;
                    lblSecimler[i].ForeColor = RenkYesil;
                }
                else if (i == secilenIdx && secilenIdx != dogru)
                {
                    pnlSecimler[i].BackColor = RenkKirmiziAcik;
                    lblHarfler[i].ForeColor = RenkKirmizi;
                    lblSecimler[i].ForeColor = RenkKirmizi;
                }
                else
                {
                    pnlSecimler[i].BackColor = RenkKart;
                    lblHarfler[i].ForeColor = RenkIkincil;
                    lblSecimler[i].ForeColor = RenkIkincil;
                }
                pnlSecimler[i].Invalidate();
            }

            if (secilenIdx == dogru)
            {
                dogruSayisi++;
                lblGeri.Text = "✔  Doğru cevap!";
                lblGeri.ForeColor = RenkYesil;
            }
            else
            {
                yanlisSayisi++;
                lblGeri.Text = $"✘  Yanlış!  Doğru cevap: {sorular[mevcutIndex].Secenekler[dogru]}";
                lblGeri.ForeColor = RenkKirmizi;
            }

            lblGeri.Visible = true;
            lblDogru.Text = $"✔  Doğru: {dogruSayisi}";
            lblYanlis.Text = $"✘  Yanlış: {yanlisSayisi}";

            if (mevcutIndex == sorular.Count - 1)
                btnSonraki.Text = "Sonuçları Gör  →";
        }

        private void SoruYukle()
        {
            if (mevcutIndex >= sorular.Count) { SonucGoster(); return; }

            cevapVerildi = false;
            btnSonraki.Enabled = false;
            btnSonraki.Text = "Sonraki Soru  →";
            lblGeri.Visible = false;

            Soru s = sorular[mevcutIndex];
            lblSoruNo.Text = $"Soru {mevcutIndex + 1} / {sorular.Count}";
            lblSoruMetni.Text = s.Metin;
            lblIlerleme.Text = $"İlerleme: {mevcutIndex + 1} / {sorular.Count}";

            pnlIlerlemeDolu.Width = (int)((mevcutIndex + 1f) / sorular.Count * 700);

            for (int i = 0; i < 4; i++)
            {
                lblSecimler[i].Text = s.Secenekler[i];
                pnlSecimler[i].BackColor = RenkKart;
                lblHarfler[i].ForeColor = RenkMavi;
                lblSecimler[i].ForeColor = RenkMetin;
                pnlSecimler[i].Cursor = Cursors.Hand;
                pnlSecimler[i].Invalidate();
            }
        }

        private void BtnSonraki_Click(object sender, EventArgs e)
        {
            mevcutIndex++;
            SoruYukle();
        }

        private void SonucGoster()
        {
            this.Controls.Clear();
            this.BackColor = RenkArka;

            int toplam = sorular.Count;
            int puan = (int)Math.Round((double)dogruSayisi / toplam * 100);
            Color renkPuan = puan >= 70 ? RenkYesil : puan >= 50 ? Color.FromArgb(180, 130, 0) : RenkKirmizi;
            string mesaj = puan >= 70 ? "Harika bir sonuç, tebrikler!"
                           : puan >= 50 ? "Fena değil, biraz daha çalışabilirsin."
                                        : "Daha fazla çalışman gerekiyor.";

            Panel kart = new Panel
            {
                Location = new Point(75, 90),
                Size = new Size(550, 420),
                BackColor = RenkKart
            };
            kart.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var path = YuvarlatilmisYol(new Rectangle(0, 0, kart.Width - 1, kart.Height - 1), 14))
                using (var pen = new Pen(RenkSinir, 1.5f))
                    e.Graphics.DrawPath(pen, path);
            };

            Label lBaslik = new Label
            {
                Text = "Test Tamamlandı!",
                Location = new Point(0, 36),
                Size = new Size(550, 38),
                Font = new Font("Segoe UI", 17f, FontStyle.Bold),
                ForeColor = RenkMetin,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Label lPuan = new Label
            {
                Text = $"%{puan}",
                Location = new Point(150, 88),
                Size = new Size(250, 96),
                Font = new Font("Segoe UI", 56f, FontStyle.Bold),
                ForeColor = renkPuan,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Panel pnlD = new Panel { Location = new Point(75, 200), Size = new Size(180, 52), BackColor = RenkYesilAcik };
            pnlD.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var path = YuvarlatilmisYol(new Rectangle(0, 0, pnlD.Width - 1, pnlD.Height - 1), 8))
                    e.Graphics.FillPath(new SolidBrush(RenkYesilAcik), path);
            };
            Label lD = new Label { Text = $"✔  {dogruSayisi} Doğru", Location = new Point(0, 0), Size = new Size(180, 52), Font = new Font("Segoe UI", 11f, FontStyle.Bold), ForeColor = RenkYesil, TextAlign = ContentAlignment.MiddleCenter };
            pnlD.Controls.Add(lD);

            Panel pnlY = new Panel { Location = new Point(295, 200), Size = new Size(180, 52), BackColor = RenkKirmiziAcik };
            pnlY.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var path = YuvarlatilmisYol(new Rectangle(0, 0, pnlY.Width - 1, pnlY.Height - 1), 8))
                    e.Graphics.FillPath(new SolidBrush(RenkKirmiziAcik), path);
            };
            Label lY = new Label { Text = $"✘  {yanlisSayisi} Yanlış", Location = new Point(0, 0), Size = new Size(180, 52), Font = new Font("Segoe UI", 11f, FontStyle.Bold), ForeColor = RenkKirmizi, TextAlign = ContentAlignment.MiddleCenter };
            pnlY.Controls.Add(lY);

            Label lMesaj = new Label
            {
                Text = mesaj,
                Location = new Point(0, 272),
                Size = new Size(550, 28),
                Font = new Font("Segoe UI", 11f, FontStyle.Italic),
                ForeColor = renkPuan,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Button btnYeniden = new Button
            {
                Text = "Testi Yeniden Başlat",
                Location = new Point(125, 328),
                Size = new Size(300, 50),
                BackColor = RenkMavi,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11f, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnYeniden.FlatAppearance.BorderSize = 0;
            btnYeniden.Click += (s, e) =>
            {
                mevcutIndex = 0; dogruSayisi = 0; yanlisSayisi = 0;
                this.Controls.Clear();
                ArayuzOlustur();
                SoruYukle();
            };

            kart.Controls.Add(lBaslik);
            kart.Controls.Add(lPuan);
            kart.Controls.Add(pnlD);
            kart.Controls.Add(pnlY);
            kart.Controls.Add(lMesaj);
            kart.Controls.Add(btnYeniden);
            this.Controls.Add(kart);
        }
    }
}
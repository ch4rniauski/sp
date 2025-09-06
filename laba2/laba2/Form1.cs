using laba2.Structs;
using System.Drawing.Drawing2D;

namespace laba2
{
    public partial class Form1 : Form
    {
        private readonly Planet[] _planets;
        private readonly Font _planetFont = new("Calibri", 10);

        public Form1()
        {
            InitializeComponent();

            _planets =
            [
                new Planet { Name = "Солнце", DistanceFromSun = 0, Size = 40, Color = Color.Yellow, RotationSpeed = 0 },
                new Planet { Name = "Меркурий", DistanceFromSun = 80, Size = 8, Color = Color.Gray, RotationSpeed = 0.1f },
                new Planet { Name = "Венера", DistanceFromSun = 100, Size = 12, Color = Color.Orange, RotationSpeed = 0.08f },
                new Planet { Name = "Земля", DistanceFromSun = 130, Size = 14, Color = Color.Blue, RotationSpeed = 0.06f },
                new Planet { Name = "Луна", DistanceFromSun = 150, Size = 6, Color = Color.Gray, RotationSpeed = 0.12f },
                new Planet { Name = "Марс", DistanceFromSun = 160, Size = 10, Color = Color.Red, RotationSpeed = 0.04f },
                new Planet { Name = "Юпитер", DistanceFromSun = 220, Size = 30, Color = Color.Brown, RotationSpeed = 0.02f },
                new Planet { Name = "Сатурн", DistanceFromSun = 280, Size = 25, Color = Color.Gold, RotationSpeed = 0.015f },
                new Planet { Name = "Уран", DistanceFromSun = 340, Size = 18, Color = Color.LightBlue, RotationSpeed = 0.01f },
                new Planet { Name = "Нептун", DistanceFromSun = 400, Size = 16, Color = Color.DarkBlue, RotationSpeed = 0.008f }
            ];

            animationTimer.Tick += AnimationTimer_Tick!;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;

            DrawOrbits(g);
            DrawPlanets(g);
        }

        private void DrawOrbits(Graphics g)
        {
            var center = new Point(Width / 2, Height / 2);

            using var orbitPen = new Pen(Color.White, 1);

            for (int i = 1; i < _planets.Length; i++)
            {
                float distance = _planets[i].DistanceFromSun;

                g.DrawEllipse(
                    orbitPen,
                    center.X - distance,
                    center.Y - distance,
                    distance * 2, distance * 2);
            }
        }

        private void DrawPlanets(Graphics g)
        {
            var center = new Point(Width / 2, Height / 2);

            for (int i = 0; i < _planets.Length; i++)
            {
                var state = g.Save();

                g.TranslateTransform(center.X, center.Y); // перенос начала координат в центр с левого верхнего угла

                if (i > 0)
                {
                    float angleDegrees = _planets[i].RotationAngle * 180f / (float)Math.PI;

                    g.RotateTransform(angleDegrees); // сгибаем ось X в круг, для движения планет
                    g.TranslateTransform(_planets[i].DistanceFromSun, 0); // сдвигает точку рисования
                }

                if (_planets[i].Name == "Солнце")
                {
                    var rect = new RectangleF(-_planets[i].Size / 2, -_planets[i].Size / 2, _planets[i].Size, _planets[i].Size);

                    using var gradientBrush = new LinearGradientBrush(rect,Color.Orange, Color.DarkOrange, 45f);

                    g.FillEllipse(gradientBrush, rect);
                }
                else
                {
                    using var planetBrush = new SolidBrush(_planets[i].Color);

                    var rect = new RectangleF(-_planets[i].Size / 2, -_planets[i].Size / 2, _planets[i].Size, _planets[i].Size);

                    g.FillEllipse(planetBrush, rect);
                }

                if (i == 0)
                {
                    using var textBrush = new SolidBrush(Color.White);

                    SizeF textSize = g.MeasureString(_planets[i].Name, _planetFont);

                    g.DrawString(_planets[i].Name, _planetFont, textBrush, -textSize.Width / 2, _planets[i].Size / 2 + 5);
                }
                else
                {
                    g.ResetTransform();

                    using var textBrush = new SolidBrush(Color.White);

                    float textX = center.X + (float)(Math.Cos(_planets[i].RotationAngle) * _planets[i].DistanceFromSun);
                    float textY = center.Y + (float)(Math.Sin(_planets[i].RotationAngle) * _planets[i].DistanceFromSun) + _planets[i].Size / 2 + 5;

                    SizeF textSize = g.MeasureString(_planets[i].Name, _planetFont);

                    g.DrawString(_planets[i].Name, _planetFont, textBrush, textX - textSize.Width / 2, textY);
                }

                g.Restore(state);
            }
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 1; i < _planets.Length; i++) // Обновляем углы поворота планет
            {
                _planets[i].RotationAngle += _planets[i].RotationSpeed;

                if (_planets[i].RotationAngle > Math.PI * 2)
                {
                    _planets[i].RotationAngle = 0;
                }
            }

            Invalidate(); // Перерисовываем форму
        }
    }
}

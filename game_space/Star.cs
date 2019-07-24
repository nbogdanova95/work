using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace game_space
{
    class Star:BaseObject
    {
        Image star = Image.FromFile(@"..\..\kos.png");
        public Star(Point pos,Point dir,Size size):base(pos,dir,size)
        {

        }

        public override void Draw()
        {
           Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
           Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
           Game.Buffer.Graphics.DrawImage(star, Pos.X - 100, Pos.Y + 300, 15, 15);
        }

        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}

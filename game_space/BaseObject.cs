using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace game_space
{
    /// <summary>
    /// Базовый обект, от которого наследуются остальные
    /// </summary>
    abstract class BaseObject :ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;


        /// <summary>
        /// Конструктор  базового объекта
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="size"></param>
        public BaseObject(Point pos,Point dir,Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;

            //Проверка что размер объекта не отрицательное число
            if (size.Width < 0 || size.Height < 0)
            {
                throw new GameObjectException(
                    "При создании объекта произошла ошибка.\n Размер объекта должен быть положительным числом");
            }

            // Проверка что скорость объекта не превышает 100
            if (Dir.X > 100 || Dir.Y > 100)
            {
                throw new GameObjectException(
                    "При создании объекта произошла ошибка.\n скорость объекта должен быть не больше 100");
            }

        }

        public delegate void Message();

        /// <summary>
        /// Отрисовка объекта будет реализована в классах-наследниках, здесь реализации нет, так как метод абстрактный
        /// </summary>
        public abstract void Draw();

       

        /// <summary>
        /// Движение объекта
        /// </summary>
        public abstract void Update();
        

        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
        public Rectangle Rect => new Rectangle(Pos, Size);

       
    }
}

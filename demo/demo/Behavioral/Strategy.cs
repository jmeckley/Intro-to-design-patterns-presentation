using System;
using System.IO;
using System.Text;

namespace demo.Behavioral
{
    class Strategy
        : IDemo
    {
        public void Demo(TextWriter writer)
        {
            var character = new Character();
            character.Weapon = new Sword();

            var attack = character.Attack();
            Console.WriteLine(attack);

            character.Weapon = new Axe();

            attack = character.Attack();
            Console.WriteLine(attack);
        }
    }

    class Character
    {
        public IWeapon Weapon { get; set; }

        public string Attack()
        {
            return string.Format("attacking opponent with {0}", Weapon.Name);
        }
    }

    interface IWeapon
    {
        string Name {get;}
    }

    class Sword
        : IWeapon
    {
        public string Name { get { return "Sword"; } }
    }

    class Axe
        : IWeapon
    {
        public string Name { get { return "Axe"; } }
    }

    class Bow
        : IWeapon
    {
        public string Name { get { return "Bow"; } }
    }
}

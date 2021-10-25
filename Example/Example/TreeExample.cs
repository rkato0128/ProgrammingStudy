using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    // 트리 자료구조 학습

    class Tree<T>
    {
        public TreeNode<T> rootNode;

        public Tree(T root)
        {
            rootNode = new TreeNode<T>(root);
        }
    }

    class TreeNode<T>
    {
        List<TreeNode<T>> childrenNode = new List<TreeNode<T>>();
        public T data;

        public TreeNode(T node)
        {
            data = node;
        }

        public void AddNode(T node)
        {
            TreeNode<T> childNode = new TreeNode<T>(node);
            childrenNode.Add(childNode);
        }

        public void SearchChild()
        {
            if (typeof(T) == typeof(Monster)) // (data is Monster)
            {
                Monster monster = data as Monster;

                Console.WriteLine("몬스터 이름 : " + monster.Name + ", 체력 : " + monster.Hp + ", 공격력 : " + monster.Atk);

                for (int i = 0; i < childrenNode.Count(); i++)
                {
                    childrenNode[i].SearchChild();
                }
            }
        }
    }

    class Monster
    {
        public string Name;
        public int Hp;
        public int Atk;

        public Monster(string name, int hp, int atk)
        {
            Name = name;
            Hp = hp;
            Atk = atk;
        }
    }

    class Goblin : Monster
    {
        public Goblin(string name, int hp, int atk) : base(name, hp, atk)
        { 
            
        }
    }

    class SuperGoblin : Monster
    {
        public SuperGoblin(string name, int hp, int atk) : base(name, hp, atk)
        {

        }
    }

    class TreeExample
    {
        static void Main()
        {
            Goblin goblinMaster = new Goblin("고블린 주인", 100, 10);
            SuperGoblin goldGoblin = new SuperGoblin("황금 고블린", 500, 300);
            SuperGoblin sliverGoblin = new SuperGoblin("은 고블린", 200, 200);
            SuperGoblin copperGoblin = new SuperGoblin("동 고블린", 150, 100);

            Tree<Monster> monsterTree = new Tree<Monster>(goblinMaster);

            monsterTree.rootNode.AddNode(goldGoblin);
            monsterTree.rootNode.AddNode(sliverGoblin);
            monsterTree.rootNode.AddNode(copperGoblin);

            monsterTree.rootNode.SearchChild();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO; // 파일과 데이터 스트림에 대한 읽기 및 쓰기를 허용하는 형식과 기본 파일 및 디렉터리 지원을 제공하는 형식이 포함

namespace Example
{
    class DirTree
    {
        public DirTreeNode rootDirNode;

        public DirTree(string root)
        {
            rootDirNode = new DirTreeNode(root, 0);
        }
    }

    class DirTreeNode
    {
        List<DirTreeNode> childrenDirNodeList = new List<DirTreeNode>();

        public string dirName;
        private string dir;
        private int treeLevel;

        public DirTreeNode(string directory, int level)
        {
            dir = directory;
            treeLevel = level;

            // 디렉토리 경로에서 현재 디렉토리 이름만 분리
            string[] split = dir.Split('\\');
            dirName = split[split.Length - 1];

            // return; // 생성자에서 자신의 데이터를 반환하면, 생성과 동시에 자료에 자신의 데이터를 저장할 수 있음.
        }

        public void AddAllChildrenDir() // 디렉토리 트리형 자료구조 생성
        {
            string[] dirs = Directory.GetDirectories(dir);

            foreach (string directory in dirs)
            {
                DirTreeNode childNode = new DirTreeNode(directory, treeLevel + 1);
                childrenDirNodeList.Add(childNode);

                childNode.AddAllChildrenDir();
            }
        }

        public void PrintAllChildrenDir() // 모든 하위 디렉토리명 출력
        {
            for (int i = 0; i < treeLevel; i++) // 트리 레벨에 따라 공백 생성
            {
                Console.Write("     ");
            }

            Console.WriteLine(dirName);

            foreach (DirTreeNode node in childrenDirNodeList)
            {
                node.PrintAllChildrenDir();
            }
        }
    }


    class ExTree
    {
        static void Main()
        {
            string targetDirectory;

            Console.Write("하위 폴더 및 파일을 탐색할 위치를 입력해주세요 : ");
            targetDirectory = Console.ReadLine();

            DirTree dirTree = new DirTree(targetDirectory); // 디렉토리 트리 구조 생성

            dirTree.rootDirNode.AddAllChildrenDir();
            dirTree.rootDirNode.PrintAllChildrenDir();



            // 테스트용 구문

            //try
            //{
            //    string[] dirs = Directory.GetDirectories(targetDirectory);
            //    //string[] dirs = Directory.GetDirectories("C:\\"); // @ 안붙여도 입력됨

            //    for (int i = 0; i < dirs.Length; i++)
            //    {
            //        string[] tempSplit = dirs[i].Split('\\');
            //        Console.WriteLine(tempSplit[tempSplit.Length - 1]);
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("The process failed : {0}", e.ToString());
            //}

        }
    }
}

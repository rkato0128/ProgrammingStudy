using System;
using System.Collections;
using System.Collections.Generic;

namespace Example
{
    // Dictionary 예제

    class Library
    {
        private Dictionary<string, Dictionary<string, List<string>>> libraryData;

        // 도서관 데이터 추가
        public Library()
        {
            libraryData = new Dictionary<string, Dictionary<string, List<string>>>();

            Dictionary<string, List<string>> classicalLiteraturePublisher = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> lightNovelPublisher = new Dictionary<string, List<string>>();

            libraryData.Add("Classical", classicalLiteraturePublisher);
            libraryData.Add("LightNovel", lightNovelPublisher);

            // 출판사 & 도서 추가

            List<string> minumsa = new List<string>();
            minumsa.Add("인간 실격");
            minumsa.Add("이방인");
            minumsa.Add("전쟁과 평화");
            classicalLiteraturePublisher.Add("Minumsa", minumsa);

            List<string> theStroy = new List<string>();
            theStroy.Add("데미안");
            theStroy.Add("어린왕자");
            theStroy.Add("월든");
            classicalLiteraturePublisher.Add("TheStory", theStroy);

            List<string> daewonCI = new List<string>();
            daewonCI.Add("너의 이름은");
            daewonCI.Add("날씨의 아이");
            daewonCI.Add("스즈미야 하루히의 직관");
            lightNovelPublisher.Add("DaewonCI", daewonCI);

            List<string> haksan = new List<string>();
            haksan.Add("무직전생");
            haksan.Add("늑대와 향신료");
            haksan.Add("알바 뛰는 마왕님");
            lightNovelPublisher.Add("Haksan", haksan);
        }

        public void Search()
        {
            PrintCategory();

            Console.WriteLine("\n도서 카테고리를 입력하세요.");
            string category = Console.ReadLine();

            PrintPublisher(category);

            Console.WriteLine("\n도서 리스트를 볼 출판사를 입력하세요.");
            string pub = Console.ReadLine();

            PrintBookList(category, pub);
        }
        
        public void PrintCategory()
        {
            // 도서관의 카테고리 모두 출력

            Console.WriteLine("도서 카테고리");

            foreach (string item in libraryData.Keys)
            {
                Console.WriteLine("- {0}", item);
            }
        }

        public void PrintPublisher(string category)
        {
            // 도서관 카테고리의 출판사 모두 출력

            if (libraryData.ContainsKey(category))
            {
                Console.WriteLine("\n{0} 출판사", category);

                foreach (string item in libraryData[category].Keys)
                {
                    Console.WriteLine("- {0}", item);
                }

            }
            else
            {
                Console.WriteLine("- 해당하는 카테고리가 없습니다.");
            }
        }

        public void PrintBookList(string category, string publisher)
        {
            // 도서관 카테고리 - 출판사의 책 모두 출력

            if (libraryData[category].ContainsKey(publisher))
            {
                Console.WriteLine("\n{0} 의 도서", publisher);

                foreach (string item in libraryData[category][publisher])
                {
                    Console.WriteLine("- {0}", item);
                }

            }
            else
            {
                Console.WriteLine("- 해당하는 출판사가 없습니다.");
            }
        }
    }

    class ExDictionary
    {
        static void Main()
        {
            Library myLibrary = new Library();

            myLibrary.Search();
        }
    }
}

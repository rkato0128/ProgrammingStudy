using System;
using System.Collections;
using System.Collections.Generic;

namespace Example
{
    // Dictionary 예제

    class Library
    {
        private Dictionary<string, Dictionary<string, List<string>>> libraryData;

        public Library()
        {
            libraryData = new Dictionary<string, Dictionary<string, List<string>>>();
        }

        public void Menu()
        {


        }

        
        public void PrintCategory()
        {
            // 도서관의 카테고리 모두 출/

            foreach (string item in libraryData.Keys)
            {
                Console.WriteLine("- {0}", item);
            }
        }

        public void PrintPublisher()
        {
            // 도서관 카테고리의 출판사 모두 출력
        }

        public void PrintBookList()
        {
            // 도서관 카테고리 - 출판사의 책 모두 출력
            
        }

        public void GetCategoryPublisher(string key)
        {
            if (libraryData.ContainsKey(key))
            {

            }
            else
            {
                Console.WriteLine("해당하는 도서 카테고리가 없습니다.");
            }
        }

        public void AddBook(string bookName, string publisherName, string category)
        {
            bool isBookExist = false;
            bool isPublisherExist = false;
            bool isCategoryExist = false;


            if (libraryData.ContainsKey(category))
            {
                isCategoryExist = true;

                if (libraryData.ContainsKey(publisherName))
                {
                    isPublisherExist = true;


                    if (libraryData.ContainsKey(bookName))
                    {
                        isBookExist = true;

                    }
                }
            }


            if (libraryData.ContainsKey(category))
            {

            }
            else
            {
                Dictionary<string, List<string>> categoryPublisher = new Dictionary<string, List<string>>();
            }
        }
    }

    class ExDictionary
    {
        static void Main()
        {
            Dictionary<string, Dictionary<string, List<string>>> bookCategory = new Dictionary<string, Dictionary<string, List<string>>>();

            Dictionary<string, List<string>> classicalLiteraturePublisher = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> domesticNovelPublisher = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> foreignLiteraturePublisher = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> lightNovelPublisher = new Dictionary<string, List<string>>();

            bookCategory.Add("Classical", classicalLiteraturePublisher);
            bookCategory.Add("Domestic", domesticNovelPublisher);
            bookCategory.Add("Foreign", foreignLiteraturePublisher);
            bookCategory.Add("LightNovel", lightNovelPublisher);

            List<string> haksan = new List<string>();


        }
    }
}

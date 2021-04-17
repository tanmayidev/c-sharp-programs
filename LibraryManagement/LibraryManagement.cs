using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibraryManagement
{
	public class Library
	{

		SortedList<int, string> books = new SortedList<int, string>();

		public void addBook(int isbn, string title)
		{
			books.Add(isbn, title);
		}

		public void removeBook(int isbn)
		{
			Console.WriteLine("ISBN of removed book is " + isbn);
			books.Remove(isbn);
		}

		public void displayBook(int isbn)
		{
			try{
				Console.WriteLine("ISBN : " + isbn + " and Title : " + books[isbn] + "\n");
			}
			catch (Exception ) {
				Console.WriteLine("Entered ISBN does not exist");
			}
		}

		public void displayAllBooks()
        {
			try
			{
				foreach (int key in books.Keys)
				{
					Console.WriteLine("ISBN : " + key + " and Title : " + books[key] + "\n");
				}
			}
			catch (Exception )
            {
				Console.WriteLine("The Library is Empty");
            }
        }
	}


	class Program
	{
		public static void Main()
		{
		  int choice;
		     int isbn;
			string title;
			Library myBook = new Library();

			for (; ; )
			{
				Console.WriteLine("-------Library Management System Menu---------");
				Console.WriteLine("1. Add ");
				Console.WriteLine("2. Remove ");
				Console.WriteLine("3. Display ");
				Console.WriteLine("4. Display all Books In Library ");
				Console.WriteLine("5. Exit ");
				Console.WriteLine("Enter your choice:");

				choice = Convert.ToInt32(Console.ReadLine());

				if (choice == 1)
				{
					Console.WriteLine("Enter the ISBN: ");
					isbn = Convert.ToInt32(Console.ReadLine());

					Console.WriteLine("Enter the Title: ");
					title = Console.ReadLine();

					myBook.addBook(isbn, title);
				}
				else if (choice == 2)
				{
					Console.WriteLine("Enter the ISBN: ");
					isbn = Convert.ToInt32(Console.ReadLine());
					myBook.removeBook(isbn);
				}
				else if (choice == 3)
				{
					Console.WriteLine("Enter the ISBN: ");
					isbn = Convert.ToInt32(Console.ReadLine());

					myBook.displayBook(isbn);
				}
				else if (choice == 4)
				{ 
					myBook.displayAllBooks();
				}
				else if (choice == 5)
				{
					Console.WriteLine("Exited");
					break;
				
				}
				else 
				{
					Console.WriteLine("Please enter the valid option");
				}

			}
		}
	}
}

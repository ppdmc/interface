using System;
using static System.Console;

namespace interface
{

    /// 인터페이스 다형성 예제 시작
    interface IListtable
    {
        //해당 행에서 각 열의 값을 반환한다.
        string[] ColumnValues
        {
            get;
        } 
    }

    public abstract class PdaItem
    {
        public PdaItem(string name)
        {
            Name = name;
        }

        public virtual string Name{get; set;}
    }

    class Contanct : PdaIteme, IListtable
    {
        public Contact(string firstName, string lastName, string address, string phone) : base(null)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Phone = phone;
        }

        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Address {get; set;}
        public string Phone {get; set;}

        public string[] ColumnValues
        {
            get
            {
                return new string[]
                {
                    FirstName,
                    LastName,
                    Phone,
                    Address
                };
            }
        }

        public static string[] Headers
        {
            get
            {
                return new string[]
                {
                    "Fist Name", "Last Name", "Phone", "Address"
                };
            }
        }
    }

    class publication : IListtable
    {
        public publication(string title, string author, int year)
        {
            Title = title;
            Author = author;
            Year = year;
        }

        public string Title {get; set;}
        public string Author {get; set;}
        public string Year {get; set;}

        public string[] ColumnValues
        {
            get
            {
                return new string[]
                {
                    Title,
                    Author,
                    Year.Tostring()
                };
            }
        }

        public static string[] Headers
        {
            get
            {
                return new string[]
                {
                    "Title",
                    "Author",
                    "Year"
                };
            }
        }
    }

    class Program
    {
        public static void Main()
        {
             Contact[] contacts = new Contact[6];
             contacts[0] = new Contact(
                 "Dick", "Traci",
                 "123 Main St., Spokane, WA 99037",
                 "123-123-1234"
             );
             contacts[1] = new Contact(
                 "Lee", "Littman",
                 "123 Main St., Spokane, WA 99037",
                 "123-123-1234"
             );
             contacts[2] = new Contact(
                 "Park", "Hartfilt",
                 "123 Main St., Spokane, WA 99037",
                 "123-123-1234"
             );
             contacts[3] = new Contact(
                 "Kim", "Lindherst",
                 "123 Main St., Spokane, WA 99037",
                 "123-123-1234"
             );
             contacts[4] = new Contact(
                 "Jang", "Wilson",
                 "123 Main St., Spokane, WA 99037",
                 "123-123-1234"
             );
             contacts[5] = new Contact(
                 "Gi", "Doe",
                 "123 Main St., Spokane, WA 99037",
                 "123-123-1234"
             );

             //클래스에서 지원하는 인터페이스로 암시적인 캐스팅이 일어난다.
             ConsoleListControl.List(Contact.Headers, contacts);

             Console.WriteLine();

             Publication[] publications = new Publication[3]{
                 new Publication("Celebration of Discipline" , "Richard Foster" , 1978),
                 new Publication("Orthodoxy" , "G.K. Chesterton" , 1908),
                 new Publication("The Hitchhiker's Guide to the Galaxy" , "Douglas Adams" , 1979)
             };

             ConsoleListControl.List(Publication.Headers, publications);
        }
    }

    class ConsoleListControl
    {
        public static void List (string[] headers, IListtable[] items)
        {
            int[] columnWidths = DisplayHeaders(headers);

            for (int count = 0; count < items.Length; count++)
            {
                string[] values = items[count].ColumnValues;
                DisplayItemRow(columnWidths, values);
            }
        }

        /// <summary>열 헤더 표시</summary>
        /// <returns>열 너비 배열 반환</returns>
        private static int[] DisplayHeaders(string[] headers)
        {
            //..
        }

        private static void DisplayItemRow(int[] columnWidths, string[] values)
        {
            //...
        }
    }

    /// 인터페이스 구현 예제 시작
    public class Contact : PdaItem. IListable, IComparable
    {
        //..
        #region IComparable 멤버
        /// <summary>
        ///
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>
        /// Less than zero
        /// Zero
        /// Greater than zero
        /// </returns>

        public int CompareTo(object obj)
        {
            int result;
            Contact contact = obj as Contact;

            if(obj == null)
            {
                // 이 인스턴스는  obj보다 크다
                result = 1;
            }
            else if (obj != typeof(Contanct))
            {
                // 메세지에서 c#6.0 nameof 연산자를 사용해 형식 이름에 일관성을 보장한다.
                throw new ArgumentException(
                    $"The parameter is not a of type {nameof(Contact)}",nameof(obj));
            }
            else if(Contact.ReferenceEquals(this, obj))
            {
                result = 0;
            }
            else
            {
                result = LastName.CompareTo(contact.LastName);
                if(result == 0)
                {
                    result = FitstName.CompareTo(contact.FitdtName);
                }
            }

            return result;
        }
        #endregion

        #region iListable 멤버
        string[] IListable.ColumnValues
        {
            get
            {
                return new string[]
                {
                    FirstName,
                    LastName,
                    Phone,
                    Address
                };
            }
        }

        #endregion
    }

    // 인터페이스 명시적구현 예제 시작
    string[] values;
    Contact contact1, contact2;

    //..

    // 에러 : contact에서 ColumnValues()를 직접 호출 할 수 없다.
    // values = ((IListable)contact2).ColumnValues;

    //먼저 IListable로 형변환 한다.
    values = ((IListable)contact2).ColumnValues;
    //..
    

    public class Contact : PdaItem, IListable, IComparable
    {
        // ...

        public int CompareTo(object obj)
        {
            // ...
        }
        #region IListable 멤버
        string[] IListable.ColumnValues
        {
            get
            {
                return new string[]
                {
                    FirstName,
                    LastName,
                    Phone,
                    Address
                };
            }
        }
        #endregion
    }

    public interface IAction
    {
        void Act();
        void React();
    }

    public class Person : IAction
    {
        public void Act()
        {            
        }

        void IAction.React()
        {         
        }
    }

    interface IReadableSettingsProvider
    {
        string GetSetting(string name, string defaultValue);
    }

    interface ISettingsProvider : IReadableSettingsProvider
    {
        void SetSetting(string name, string value);
    }

    class FileSettingsProvider : ISettingsProvider
    {
        #region ISettingsProvider 멤버
        public void SetSettings(string name, string value)
        {
            //...
        }
        #endregion

        #region IReadableSettingsProvider Menbers
        public sting GetSetting(string name, string defaultValue)
        {
            //...
        }
        #endregion
    }
}
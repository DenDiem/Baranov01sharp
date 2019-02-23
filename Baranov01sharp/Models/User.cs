using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baranov01sharp.Model
{
    class User
    {
        private int _userBirthdayDay;
        private int _userBirthdayMonth;
        private int _userBirthdayYear;

        private static User instance;

        private static object locker = new object();
        private int _age;

        private User()
        {


        }
        internal static User Instance
        {
            get
            {
                lock (locker)
                {
                    if (instance == null)
                    {
                        instance = new User();
                        instance.InitUser(-1,-1,-1);
                    }
                }

                return instance;
            }
        }
        public void InitUser(int day, int month, int year)
        {
            UserBirthdayDay = day;
            UserBirthdayMonth = month;
            UserBirthdayYear = year;

        }
        public int CalculateAge()
        {
            if (UserBirthdayDay == -1)
                return "Error Code -1";
            if (DateTime.Now.Month < UserBirthdayMonth || DateTime.Now.Month == UserBirthdayMonth && DateTime.Now.Day < UserBirthdayDay )
                return DateTime.Now.Year - UserBirthdayYear - 1;
            return DateTime.Now.Year - UserBirthdayYear;
        }

        public int Age
        {
            get
            {
                return CalculateAge();
            }
        }

        public String CalculateSimpleSign()
        {
            if (UserBirthdayDay == -1)
                return "Error Code -1";
            if (UserBirthdayDay <= 20 && UserBirthdayMonth <= 1)
                return "Козерог";
            if (UserBirthdayDay <= 18 && UserBirthdayMonth <= 2)
                return "Водолій";
            else if (UserBirthdayDay <= 20 && UserBirthdayMonth <= 3)
                return "Риби";
            else if (UserBirthdayDay <= 20 && UserBirthdayMonth <= 4)
                return "Овен";
            else if (UserBirthdayDay <= 20 && UserBirthdayMonth <= 5)
                return "Телець";
            else if (UserBirthdayDay <= 21 && UserBirthdayMonth <= 6)
                return "Близнюки";
            else if (UserBirthdayDay <= 22 && UserBirthdayMonth <= 7)
                return "Рак";
            else if (UserBirthdayDay <= 22 && UserBirthdayMonth <= 8)
                return "Лев";
            else if (UserBirthdayDay <= 22 && UserBirthdayMonth <= 9)
                return "Діва";
            else if (UserBirthdayDay <= 23 && UserBirthdayMonth <= 10)
                return "Віси";
            else if (UserBirthdayDay <= 22 && UserBirthdayMonth <= 11)
                return "Scorpions√";
            else if (UserBirthdayDay <= 21 && UserBirthdayMonth <= 12)
                return "Стрілок";
            else 
                return "Козерог";
           
           
        }

        public String CalculateChinaSign()
        {
            if (UserBirthdayDay == -1)
                return "Error Code -1";
            int sign = UserBirthdayYear % 12;

            switch (sign)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 0:
                    break;
                case 0:
                    break;
                case 0:
                    break;
                case 0:
                    break;
                case 0:
                    break;
                case 0:
                    break;
                case 0:
                    break;

            }



        }
        public Boolean CheckBirthDay()
        {

            return UserBirthdayDay == DateTime.Now.Day && UserBirthdayMonth == DateTime.Now.Month;
        }
        public int UserBirthdayDay { get => _userBirthdayDay; set => _userBirthdayDay = value; }
        public int UserBirthdayMonth { get => _userBirthdayMonth; set => _userBirthdayMonth = value; }
        public int UserBirthdayYear { get => _userBirthdayYear; set => _userBirthdayYear = value; }
       // public int CheckBirthday { get; private set; }
    }


}

using System;
using System.Text.RegularExpressions;

namespace KMA.ProgrammingInCSharp2019.Practice5.Navigation.Models
{
    public class Person
    {
        private string _name;
        private string _lastName;
        private string _email;
        private DateTime _birth;
        private readonly bool IsAdult;
        private readonly string SunSign;
        private readonly string ChineseSign;
        private readonly bool IsBirthday;

        public Person(string name, string lastName, string email, DateTime birth)
        {
            validateName(name);
            validateName(lastName);
            validateDate(birth);
            validateEmail(email);

            _name = name;
            _lastName = lastName;
            _email = email;
            _birth = birth;
            IsAdult = CalcIsAdult();
            SunSign = CalcSunSign();
            ChineseSign = CalcChineseSign();
            IsBirthday = CalcIsBirthday();

        }

        public Person(string name, string lastName, DateTime birth) : this(name, lastName, "none", birth)
        {
        }

        public Person(string name, string lastName, string email) : this(name, lastName, email, DateTime.MinValue)
        {
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        public DateTime Birth
        {
            get
            {
                return _birth;
            }
            set
            {
                _birth = value;
            }
        }

        public bool GetIsAdult
        {
            get
            {
                return IsAdult;
            }
        }

        public string GetSunSign
        {
            get
            {
                return SunSign;
            }
        }

        public string GetChineseSign
        {
            get
            {
                return ChineseSign;
            }
        }

        public bool GetIsBirthday
        {
            get
            {
                return IsBirthday;
            }
        }

        public bool CalcIsAdult()
        {
            return CalcAge() >= 18 ? true : false;
        }

        public int CalcAge()
        {
            if (DateTime.Today.Month < _birth.Month ||
                (DateTime.Today.Month == _birth.Month && DateTime.Today.Day < _birth.Day))
            {
                return DateTime.Today.Year - _birth.Year - 1;
            }
            return DateTime.Today.Year - _birth.Year;
        }

        public string CalcSunSign()
        {
            int moth = Birth.Month;
            int day = Birth.Day;
            switch (moth)
            {
                case 1:
                    if (day <= 19)
                        return "Capricorn";
                    else
                        return "Aquarius";

                case 2:
                    if (day <= 18)
                        return "Aquarius";
                    else
                        return "Pisces";
                case 3:
                    if (day <= 20)
                        return "Pisces";
                    else
                        return "Aries";
                case 4:
                    if (day <= 19)
                        return "Aries";
                    else
                        return "Taurus";
                case 5:
                    if (day <= 20)
                        return "Taurus";
                    else
                        return "Gemini";
                case 6:
                    if (day <= 20)
                        return "Gemini";
                    else
                        return "Cancer";
                case 7:
                    if (day <= 22)
                        return "Cancer";
                    else
                        return "Leo";
                case 8:
                    if (day <= 22)
                        return "Leo";
                    else
                        return "Virgo";
                case 9:
                    if (day <= 22)
                        return "Virgo";
                    else
                        return "Libra";
                case 10:
                    if (day <= 22)
                        return "Libra";
                    else
                        return "Scorpio";
                case 11:
                    if (day <= 21)
                        return "Scorpio";
                    else
                        return "Sagittarius";
                case 12:
                    if (day <= 21)
                        return "Sagittarius";
                    else
                        return "Capricorn";
            }
            return "";
        }

        public string CalcChineseSign()
        {
            System.Globalization.EastAsianLunisolarCalendar cc = new System.Globalization.ChineseLunisolarCalendar();
            int sexagenaryYear = cc.GetSexagenaryYear(Birth);
            int terrestrialBranch = cc.GetTerrestrialBranch(sexagenaryYear);

            string[] years = new string[] { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };

            return years[terrestrialBranch - 1];
        }

        public bool CalcIsBirthday()
        {
            if (DateTime.Today.Month == _birth.Month && DateTime.Today.Day == _birth.Day)
                return true;
            return false;
        }

        private void validateName(string name)
        {
            if (name.Length < 2)
                throw new NameError("Please, print you real name. This one is too short " + name);
        }

        private void validateDate(DateTime date)
        {
            if (date > DateTime.Today)
                throw new FutureDayError(date);
            if (DateTime.Today.Year - date.Year >= 135)
                throw new PastDayError(date);
        }

        private void validateEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
                throw new EmailError("Incorrect email " + email);
        }
    }
}

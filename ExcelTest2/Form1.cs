using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace ExcelTest2
{
    public partial class Form1 : Form
    {
        PerDiemAmountsEntities db = new PerDiemAmountsEntities();
        List<string> files;
        List<string> homeAirports;
        Dictionary<string, Month> monthDays = new Dictionary<string, Month>() { {"JAN", new Month(31, 31, "DEC")}, { "FEB", new Month(28, 31, "JAN") }, { "MAR", new Month(31, 28, "FEB") }, { "APR", new Month(30, 31, "MAR") },
                { "MAY", new Month(31, 30, "APR") }, { "JUN", new Month(30, 31, "MAY") }, {"JUL", new Month(31, 30, "JUN") }, {"AUG", new Month(31, 30, "JUL") }, {"SEP", new Month(30, 31, "AUG") }, {"OCT", new Month(31, 30, "SEP") },
                { "NOV", new Month(30, 31, "OCT") }, {"DEC", new Month(31, 30, "NOV") } };
        Dictionary<string, int> perDiemByMonth;
        Dictionary<string, int> daysPerMonth;
        Dictionary<string, string> monthFiles;
        string prevDate, prevFromAirport, prevToAirport, curDate, curFromAirport, curToAirport, curMonth, fileMonth, basepath, daysStartingAirport;
        int blankLines, row, dateIndex, destinationIndex, departingIndex, totalDays, totalLayovers, totalPerDiem, year, totalShuttleFee;
        bool isDateFromFileMonth, hasMonthChanged, wasPerDiemAddedLastTrip;
        string daysForEachMonth, daysForSecondHalfOfYear;

        private void clearButton_Click(object sender, EventArgs e)
        {
            filePathTextBox.Text = "";
            homeAirportTextBox.Text = "";
        }

        public Form1()
        {
            InitializeComponent();
            yearComboBox.SelectedIndex = 1;
        }

        private void runButton_Click(object sender, EventArgs e)
        {
            Initialize();
            basepath = filePathTextBox.Text;
            if (basepath == "" || homeAirportTextBox.Text == "")
            {
                errorLabel.Text = "Please fill in all fields.";
            }
            else
            {
                monthFiles = new Dictionary<string, string>();
                DirectoryInfo d = new DirectoryInfo(basepath);
                FileInfo[] Files = d.GetFiles("*.csv"); //Getting csv files
                foreach (FileInfo file in Files)
                {
                    #region switch for all files
                    switch (file.Name.Substring(file.Name.LastIndexOf("_") + 1, 3))
                    {
                        case "JAN":
                            monthFiles.Add("JAN", basepath + "\\" + file.Name);
                            break;
                        case "FEB":
                            monthFiles.Add("FEB", basepath + "\\" + file.Name);
                            break;
                        case "MAR":
                            monthFiles.Add("MAR", basepath + "\\" + file.Name);
                            break;
                        case "APR":
                            monthFiles.Add("APR", basepath + "\\" + file.Name);
                            break;
                        case "MAY":
                            monthFiles.Add("MAY", basepath + "\\" + file.Name);
                            break;
                        case "JUN":
                            monthFiles.Add("JUN", basepath + "\\" + file.Name);
                            break;
                        case "JUL":
                            monthFiles.Add("JUL", basepath + "\\" + file.Name);
                            break;
                        case "AUG":
                            monthFiles.Add("AUG", basepath + "\\" + file.Name);
                            break;
                        case "SEP":
                            monthFiles.Add("SEP", basepath + "\\" + file.Name);
                            break;
                        case "OCT":
                            monthFiles.Add("OCT", basepath + "\\" + file.Name);
                            break;
                        case "NOV":
                            monthFiles.Add("NOV", basepath + "\\" + file.Name);
                            break;
                        case "DEC":
                            monthFiles.Add("DEC", basepath + "\\" + file.Name);
                            break;
                        default:
                            break;
                    }
                    #endregion
                }
                errorLabel.Text = "";
            }
            if (monthFiles != null)//there is something to read
            {
                errorLabel.Text = "";
                files = new List<string>();
                #region Add Months From Files
                if (monthFiles.ContainsKey("JAN"))
                {
                    files.Add(monthFiles["JAN"]);
                    daysPerMonth.Add("JAN", 0);
                    perDiemByMonth.Add("JAN", 0);
                }
                if (monthFiles.ContainsKey("FEB"))
                {
                    files.Add(monthFiles["FEB"]);
                    daysPerMonth.Add("FEB", 0);
                    perDiemByMonth.Add("FEB", 0);
                }
                if (monthFiles.ContainsKey("MAR"))
                {
                    files.Add(monthFiles["MAR"]);
                    daysPerMonth.Add("MAR", 0);
                    perDiemByMonth.Add("MAR", 0);
                }
                if (monthFiles.ContainsKey("APR"))
                {
                    files.Add(monthFiles["APR"]);
                    daysPerMonth.Add("APR", 0);
                    perDiemByMonth.Add("APR", 0);
                }
                if (monthFiles.ContainsKey("MAY"))
                {
                    files.Add(monthFiles["MAY"]);
                    daysPerMonth.Add("MAY", 0);
                    perDiemByMonth.Add("MAY", 0);
                }
                if (monthFiles.ContainsKey("JUN"))
                {
                    files.Add(monthFiles["JUN"]);
                    daysPerMonth.Add("JUN", 0);
                    perDiemByMonth.Add("JUN", 0);
                }
                if (monthFiles.ContainsKey("JUL"))
                {
                    files.Add(monthFiles["JUL"]);
                    daysPerMonth.Add("JUL", 0);
                    perDiemByMonth.Add("JUL", 0);
                }
                if (monthFiles.ContainsKey("AUG"))
                {
                    files.Add(monthFiles["AUG"]);
                    daysPerMonth.Add("AUG", 0);
                    perDiemByMonth.Add("AUG", 0);
                }
                if (monthFiles.ContainsKey("SEP"))
                {
                    files.Add(monthFiles["SEP"]);
                    daysPerMonth.Add("SEP", 0);
                    perDiemByMonth.Add("SEP", 0);
                }
                if (monthFiles.ContainsKey("OCT"))
                {
                    files.Add(monthFiles["OCT"]);
                    daysPerMonth.Add("OCT", 0);
                    perDiemByMonth.Add("OCT", 0);
                }
                if (monthFiles.ContainsKey("NOV"))
                {
                    files.Add(monthFiles["NOV"]);
                    daysPerMonth.Add("NOV", 0);
                    perDiemByMonth.Add("NOV", 0);
                }
                if (monthFiles.ContainsKey("DEC"))
                {
                    files.Add(monthFiles["DEC"]);
                    daysPerMonth.Add("DEC", 0);
                    perDiemByMonth.Add("DEC", 0);
                }
                #endregion

                foreach (string file in files)
                {
                    row = 1;
                    blankLines = 0;
                    try
                    {
                        StreamReader reader = new StreamReader(File.OpenRead(file));
                        List<string> listA = new List<string>();
                        fileMonth = file.Substring(file.LastIndexOf("_") + 1, 3);
                        while (!reader.EndOfStream)
                        {
                            #region starting lines
                            if (row == 1)
                            {
                                var firstLine = reader.ReadLine();
                                var firstValues = firstLine.Split(';');
                                listA = ((string)firstValues[0]).Split(',').ToList();
                                dateIndex = listA.IndexOf("DATE");
                                row++;
                                var secondLine = reader.ReadLine();
                                var secondValues = secondLine.Split(';');
                                listA = ((string)secondValues[0]).Split(',').ToList();
                                destinationIndex = listA.IndexOf("TO");
                                departingIndex = listA.IndexOf("FROM");
                                row++;
                            }
                            var line = reader.ReadLine();
                            var values = line.Split(';');
                            listA = ((string)values[0]).Split(',').ToList();
                            #endregion
                            if (curDate == "")//FirstMonth
                            {
                                SetValuesForFirstMonth(reader, listA);
                            }
                            else//new line
                            {
                                SetValuesForCurrentLine(listA);
                                if (blankLines == 2)
                                {
                                    break;
                                }
                            }
                            //If Month has not changed and data exists, do logic
                            if (!hasMonthChanged && listA.ElementAt(dateIndex) != " " && listA.ElementAt(departingIndex) != " ")
                            {
                                if (prevFromAirport == curFromAirport && prevToAirport == curToAirport)//prevent duplicate lines
                                {

                                }
                                else
                                { 
                                    if (homeAirports == null)//new trip starting
                                    {
                                        SetHomeAirport(curFromAirport);
                                    }
                                    else//on trip
                                    {
                                        if (homeAirports.Contains(curToAirport))//trip ended
                                        {
                                            if (curDate != prevDate)//add perdiem for return trip;
                                            {
                                                AddPerDiemIntraMonth(curFromAirport);
                                            }
                                        }
                                        else//new leg of trip
                                        {
                                            if (curDate != prevDate)//add perdiem for current leg;
                                            {
                                                AddPerDiemIntraMonth(prevToAirport);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                hasMonthChanged = false;
                            }

                            row++;
                        }
                        reader.Close();
                    }
                    catch (Exception ex) { errorLabel.Text = "Brandon Fucked Up"; }
                }
                if (homeAirports != null && !homeAirports.Contains(curToAirport))//Count for end of last file, use curToAirport(last airport on record)
                {
                    AddPerDiemThroughEndOfMonth(curToAirport, curDate);
                }
                #region displaying values
                perdiemAmount.Text = "$" + totalPerDiem.ToString() + " PerDiem";
                totalDaysLabel.Text = totalDays.ToString() + " Total Days Traveling";
                totalLayoversLabel.Text = totalLayovers.ToString() + " Total Number Of Layovers";
                shuttleFeeLabel.Text = "$" + (totalLayovers * 2).ToString() + " Total Shuttle Fees";
                try
                {
                    daysForEachMonth += "JAN - " + daysPerMonth["JAN"] + ": " + perDiemByMonth["JAN"] + ", ";
                }
                catch (Exception ex) { }
                try
                {
                    daysForEachMonth += "FEB - " + daysPerMonth["FEB"] + ": " + perDiemByMonth["FEB"] + ", ";
                }
                catch (Exception ex) { }
                try
                {
                    daysForEachMonth += "MAR - " + daysPerMonth["MAR"] + ": " + perDiemByMonth["MAR"] + ", ";
                }
                catch (Exception ex) { }
                try
                {
                    daysForEachMonth += "APR - " + daysPerMonth["APR"] + ": " + perDiemByMonth["APR"] + ", ";
                }
                catch (Exception ex) { }
                try
                {
                    daysForEachMonth += "MAY - " + daysPerMonth["MAY"] + ": " + perDiemByMonth["MAY"] + ", ";
                }
                catch (Exception ex) { }
                try
                {
                    daysForEachMonth += "JUN - " + daysPerMonth["JUN"] + ": " + perDiemByMonth["JUN"] + ", ";
                }
                catch (Exception ex) { }
                try
                {
                    daysForSecondHalfOfYear += "JUL - " + daysPerMonth["JUL"] + ": " + perDiemByMonth["JUL"] + ", ";
                }
                catch (Exception ex) { }
                try
                {
                    daysForSecondHalfOfYear += "AUG - " + daysPerMonth["AUG"] + ": " + perDiemByMonth["AUG"] + ", ";
                }
                catch (Exception ex) { }
                try
                {
                    daysForSecondHalfOfYear += "SEP - " + daysPerMonth["SEP"] + ": " + perDiemByMonth["SEP"] + ", ";
                }
                catch (Exception ex) { }
                try
                {
                    daysForSecondHalfOfYear += "OCT - " + daysPerMonth["OCT"] + ": " + perDiemByMonth["OCT"] + ", ";
                }
                catch (Exception ex) { }
                try
                {
                    daysForSecondHalfOfYear += "NOV - " + daysPerMonth["NOV"] + ": " + perDiemByMonth["NOV"] + ", ";
                }
                catch (Exception ex) { }
                try
                {
                    daysForSecondHalfOfYear += "DEC - " + daysPerMonth["DEC"] + ": " + perDiemByMonth["DEC"] + ", ";
                }
                catch (Exception ex) { }
                daysForMonthLabel.Text = daysForEachMonth;
                daysForMonthLabel2.Text = daysForSecondHalfOfYear;
                Console.WriteLine("Total Days: " + totalDays);
                #endregion
            }
        }

        private void AddPerDiemFromStartOfMonth()
        {
            int day, perDiem = 0;
            if (curDate.Substring(1, 1) != "-")
            {
                Int32.TryParse(curDate.Substring(0, 2), out day);
            }
            else
            {
                Int32.TryParse(curDate.Substring(0, 1), out day);
            }
            if(day != 1)//skip trips on the first of the month
            {
                var city = (from c in db.CityPerDiems where curFromAirport == c.AirportCode select c).FirstOrDefault();
                if(city != null)
                {
                    var cityPerDiemAmount = (from p in db.YearPerDiems where city.Id == p.CityId && year == p.Year select p).FirstOrDefault();
                    perDiem += cityPerDiemAmount.Meals * (day - 1);
                }
                else
                {
                    perDiem += 55 * (day - 1);
                }
                AddPerDiem(perDiem, day - 1);
            }
        }

        private void AddPerDiemIntraMonth(string airport, int returnFlight = 0)
        {
            int day1 = 0, day2 = 0, perDiem = 0;
            if (returnFlight > 0)
            {
                day2 = returnFlight;
            }
            else
            {
                int prevDateSubstringIndex = prevDate.Substring(1, 1) != "-" ? 2 : 1;
                int curDateSubstringIndex = curDate.Substring(1, 1) != "-" ? 2 : 1;
                Int32.TryParse(prevDate.Substring(0, prevDateSubstringIndex), out day1);
                Int32.TryParse(curDate.Substring(0, curDateSubstringIndex), out day2);
            }
            var city = (from c in db.CityPerDiems where airport == c.AirportCode select c).FirstOrDefault();
            if(city != null)
            {
                var cityPerDiemAmount = (from p in db.YearPerDiems where city.Id == p.CityId && year == p.Year select p).FirstOrDefault();
                perDiem += cityPerDiemAmount.Meals * (day2 - day1);
            }
            else
            {
                perDiem += 55 * (day2 - day1);
            }
            AddPerDiem(perDiem, day2 - day1, returnFlight);
        }

        private void AddPerDiemThroughEndOfMonth(string airport, string date)
        {
            if (date != "")
            {
                int day1 = 0, day2 = 0, perDiem = 0;
                if (date.Substring(1, 1) != "-")
                {
                    Int32.TryParse(date.Substring(0, 2), out day1);
                }
                else
                {
                    Int32.TryParse(date.Substring(0, 1), out day1);
                }
                day2 = monthDays[curMonth].days;
                var city = (from c in db.CityPerDiems where airport == c.AirportCode select c).FirstOrDefault();
                if(city != null)
                {
                    var cityPerDiemAmount = (from p in db.YearPerDiems where city.Id == p.CityId && year == p.Year select p).FirstOrDefault();
                    perDiem += cityPerDiemAmount.Meals * (day2 - day1 + 1);//+1 for last day inclusive
                }
                else
                {
                    perDiem += 55 * (day2 - day1 + 1);
                }
                AddPerDiem(perDiem, day2 - day1 + 1);
            }
        }

        private void AddPerDiem(int perDiemAmount, int numDays, int returnFlight = 0)
        {
            totalPerDiem += perDiemAmount;
            totalDays += numDays;
            daysPerMonth[curMonth] += numDays;
            perDiemByMonth[curMonth] += perDiemAmount;
            if (returnFlight == 0)
            {
                totalLayovers++;
                wasPerDiemAddedLastTrip = true;
            }
            else if(numDays < 0)
            {
                totalLayovers--;
            }
        }

        private void Initialize()
        {
            perDiemByMonth = new Dictionary<string, int>();
            daysPerMonth = new Dictionary<string, int>();
            prevDate = "";
            prevFromAirport = "";
            prevToAirport = "";
            curDate = "";
            curFromAirport = "";
            curToAirport = "";
            SetHomeAirport(homeAirportTextBox.Text);
            curMonth = "";
            fileMonth = "";
            blankLines = 0;
            isDateFromFileMonth = false;
            daysForEachMonth = "";
            daysForSecondHalfOfYear = "";
            totalPerDiem = 0;
            totalLayovers = 0;
            totalDays = 0;
            wasPerDiemAddedLastTrip = false;
            daysStartingAirport = "";
            year = Int32.Parse((String)yearComboBox.SelectedItem);
            totalShuttleFee = 0;

        }

        private void SetValuesForFirstMonth(StreamReader reader, List<string> list)
        {
            int substringIndex = list.ElementAt(dateIndex).Substring(2, 1) != "-" ? 2 : 3;
            string monthToCheckAgainstFile = list.ElementAt(dateIndex).Substring(substringIndex).ToUpper();
            string firstFlightAirport = list.ElementAt(departingIndex);
            while (monthToCheckAgainstFile != fileMonth || firstFlightAirport == " ")//Skip lines until the first line of the month the file is from with a real flight
            {
                var line = reader.ReadLine();
                var values = line.Split(';');
                list = ((string)values[0]).Split(',').ToList();
                if (list.ElementAt(dateIndex) != " " && list.ElementAt(departingIndex) != " ")
                {
                    monthToCheckAgainstFile = list.ElementAt(dateIndex).Substring(substringIndex).ToUpper();
                    firstFlightAirport = list.ElementAt(departingIndex);
                }
            }
            curDate = list.ElementAt(dateIndex);
            //prevDate = curDate;
            curFromAirport = list.ElementAt(departingIndex);
            daysStartingAirport = curFromAirport;
            curToAirport = list.ElementAt(destinationIndex);
            //prevFromAirport = curFromAirport;
            //prevToAirport = curToAirport;
            if (curDate.Substring(2, 1) != "-")
            {
                curMonth = curDate.Substring(2).ToUpper();
            }
            else
            {
                curMonth = curDate.Substring(3).ToUpper();
            }
            isDateFromFileMonth = curMonth == fileMonth;
            hasMonthChanged = true;
            if (!homeAirports.Contains(curFromAirport))
            {
                AddPerDiemFromStartOfMonth();
            }
        }

        private void SetValuesForCurrentLine(List<string> list)
        {
            int substringIndex = 0;
            if (list.ElementAt(dateIndex) != " " && list.ElementAt(departingIndex) != " ")
            {
                prevDate = curDate;
                prevFromAirport = curFromAirport;
                prevToAirport = curToAirport;
                curDate = list.ElementAt(dateIndex);
                substringIndex = curDate.Substring(2, 1) != "-" ? 2 : 3;
                curFromAirport = list.ElementAt(departingIndex);
                curToAirport = list.ElementAt(destinationIndex);
                if(curDate.Substring(substringIndex).ToUpper() != curMonth)//Handle change of month
                {
                    if (homeAirports != null && !homeAirports.Contains(prevToAirport))
                    {
                        AddPerDiemThroughEndOfMonth(prevToAirport, prevDate);
                    }
                    curMonth = curDate.Substring(substringIndex).ToUpper();
                    if (homeAirports != null && !homeAirports.Contains(curFromAirport))
                    {
                        hasMonthChanged = true;
                        AddPerDiemFromStartOfMonth();
                    }
                }
                if(curDate != prevDate)
                {
                    daysStartingAirport = curFromAirport;
                }
                isDateFromFileMonth = curMonth == fileMonth;
                blankLines = 0;
            }
            else if(list.ElementAt(dateIndex) == " ")//blank line, handle return to home city 
            {
                blankLines++;
                if(homeAirports != null && homeAirports.Contains(curToAirport))
                {
                    if (prevDate != "" && !homeAirports.Contains(daysStartingAirport))//dont count if user started and ended in home city in same day
                    {
                        AddPerDiemIntraMonth(daysStartingAirport, 1);
                    }
                    homeAirports = null;
                    daysStartingAirport = "";
                }
            }
        }

        private void SetHomeAirport(string curFromAirport)
        {
            string airportToUpper = curFromAirport.ToUpper();
            if (airportToUpper == "JFK" || airportToUpper == "LGA" || airportToUpper == "EWR")
            {
                homeAirports = new List<string>(new string[] { "JFK", "LGA", "EWR" });
            }
            else
            {
                homeAirports = new List<string>(new string[] { airportToUpper });
            }
            //handle when user goes to homeairport without ending a trip, remove the day that was added
            if(curDate != "" && prevDate == curDate && wasPerDiemAddedLastTrip)
            {
                RemoveOnePerDiemDay();
            }
            wasPerDiemAddedLastTrip = false;
        }

        private void RemoveOnePerDiemDay()
        {
            int perDiem = 0;
            var city = (from c in db.CityPerDiems where prevFromAirport == c.AirportCode select c).FirstOrDefault();
            if(city != null)
            {
                var cityPerDiemAmount = (from p in db.YearPerDiems where city.Id == p.CityId && year == p.Year select p).FirstOrDefault();
                perDiem += cityPerDiemAmount.Meals * (1);
            }
            else
            {
                perDiem += 55 * (1);
            }
            AddPerDiem(-perDiem, -1);
        }
    }
}

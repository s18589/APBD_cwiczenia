using Cwiczenia2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Cwiczenia2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"Data\dane.csv";

            var list = new List<Student>();
            var activeStudies = new Dictionary<string, int>();

            FileStream writer = new FileStream(@"result.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>),
                                       new XmlRootAttribute("uczelnia"));

            var fileInfo = new FileInfo(path);
            using(var stream = new StreamReader(fileInfo.OpenRead()))
            {
                string line = null;
                while((line = stream.ReadLine()) != null)
                {
                    bool notEmpty = true;
                    string[] kolumny = line.Split(',');

                    foreach (string s in kolumny){
                        if(string.IsNullOrWhiteSpace(s) || string.IsNullOrEmpty(s))
                        {
                            //zrobic obsluge bledu i wpis do loga
                            if (notEmpty) notEmpty = false;
                        }
                    }

                    if (notEmpty)
                    {
                        Student student = new Student
                        {
                            FirstName = kolumny[0],
                            LastName = kolumny[1],
                            Studies = new Studies
                            {
                                Name = kolumny[2],
                                Mode = kolumny[3]
                            },
                            StudentNumber = "s"+kolumny[4],
                            BirthDate = kolumny[5],
                            Email = kolumny[6],
                            MotherName = kolumny[7],
                            FatherName = kolumny[8]
                        };
                        list.Add(student);
                    }
                }
            }

            serializer.Serialize(writer, list);

        }
    }
}

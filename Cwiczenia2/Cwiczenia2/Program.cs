using Cwiczenia2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Cwiczenia2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"Data\dane.csv";

            var students = new List<Student>();
            var activeStudies = new SortedList<string,int>();
            var serializeList = new List<ActiveStudies>();

            FileStream writer = new FileStream(@"result.xml", FileMode.Create);
            XmlSerializer studentSerializer = new XmlSerializer(typeof(List<Student>),
                                       new XmlRootAttribute("uczelnia"));
            XmlSerializer studiesSerializer = new XmlSerializer(typeof(List<ActiveStudies>));

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
                                Mode = kolumny[3],
                            },
                            StudentNumber = "s"+kolumny[4],
                            BirthDate = kolumny[5],
                            Email = kolumny[6],
                            MotherName = kolumny[7],
                            FatherName = kolumny[8]
                        };
                        if (!activeStudies.ContainsKey(student.Studies.Mode)){
                            activeStudies.Add(student.Studies.Mode, 1);
                        }
                        else
                        {
                            activeStudies[student.Studies.Mode] += 1;
                        }
                        students.Add(student);
                    }
                }
            }
            foreach(String s in activeStudies.Keys)
            {
                serializeList.Add(new ActiveStudies
                {
                    Name = s,
                    NumberOfStudents = activeStudies[s]
                });
            }
            

            var jsonSerializer = JsonSerializer.Serialize(students);
            var jsonActiveStudies = JsonSerializer.Serialize(serializeList);
            jsonSerializer = jsonSerializer + jsonActiveStudies;
            File.WriteAllText("result.json", jsonSerializer);
            
            studentSerializer.Serialize(writer, students);
            studiesSerializer.Serialize(writer, serializeList);

            writer.Close();
            writer.Dispose();

        }
    }
}

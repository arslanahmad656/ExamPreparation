using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace PracticeProject
{
    static class XmlPracticeFile
    {
        public static void Run()
        {
            //Test();
            GenerateStudentsXml();
        }

        static void Test()
        {
            var model = new SeaEntities();
            var enrollments = model.AspNetTeacher_Enrollments.Select(e => new
            {
                EnrollmentId = e.Id,
                BranchClassSectionId = e.AspNetBranchClass_Sections.Id
            }).ToList();
        }

        static void GenerateStudentsXml()
        {
            var model = new SeaEntities();

            XNamespace ns = "StudentList";
            XElement root = new XElement(ns + "Students", model.AspNetStudents.AsEnumerable()
                .Select(s => new XElement("Student", new XAttribute("StudentId", s.Id),
                                    new XElement("Name", s.Name),
                                    new XElement("RollNumber", s.RollNo),
                                    new XElement("Enrollments",
                                        s.AspNetStudent_Enrollments
                                            .Select(e => new XElement("Enrollment", new XAttribute("EnrollmentId", e.Id),
                                                                new XElement("Course", new XAttribute("CourseId", e.AspNetCours.Id),
                                                                    new XElement("CourseName", e.AspNetCours.Name),
                                                                    new XElement("Department", e.AspNetCours.AspNetDepartment.Name)),
                                                                new XElement("Class", new XAttribute("ClassId", e.AspNetBranchClass_Sections.AspNetBranch_Class.AspNetClass.Id),
                                                                    new XElement("Grade", e.AspNetBranchClass_Sections.AspNetBranch_Class.AspNetClass.Name)),
                                                                new XElement("Section", new XAttribute("SectionId", e.AspNetBranchClass_Sections.AspNetSection.Id),
                                                                    new XElement("SectionName", e.AspNetBranchClass_Sections.AspNetSection.Name)),
                                                                new XElement("Session", new XAttribute("SessionId", e.AspNetSession.Id),
                                                                    new XElement("SessionYear", new XAttribute("Start", e.AspNetSession.StartDate.ToBinary()), new XAttribute("End", e.AspNetSession.StartDate.ToBinary()),
                                                                        $"{e.AspNetSession.StartDate:dd MMMM yyyy} - {e.AspNetSession.EndDate:dd MMMM yyyy}")),
                                                                new XElement("Branch", new XAttribute("BranchId", e.AspNetBranchClass_Sections.AspNetBranch_Class.AspNetBranch.Id),
                                                                    e.AspNetBranchClass_Sections.AspNetBranch_Class.AspNetBranch.Name))))))
                .ToList());

            //var students = model.AspNetStudents.AsEnumerable()
            //    .Select(s => new XElement("Student", new XAttribute("StudentId", s.Id),
            //                        new XElement("Name", s.Name),
            //                        new XElement("RollNumber", s.RollNo),
            //                        new XElement("Enrollments",
            //                            s.AspNetStudent_Enrollments
            //                                .Select(e => new XElement("Enrollment", new XAttribute("EnrollmentId", e.Id),
            //                                                    new XElement("Course", new XAttribute("CourseId", e.AspNetCours.Id),
            //                                                        new XElement("CourseName", e.AspNetCours.Name),
            //                                                        new XElement("Department", e.AspNetCours.AspNetDepartment.Name)),
            //                                                    new XElement("Class", new XAttribute("ClassId", e.AspNetBranchClass_Sections.AspNetBranch_Class.AspNetClass.Id),
            //                                                        new XElement("Grade", e.AspNetBranchClass_Sections.AspNetBranch_Class.AspNetClass.Name)),
            //                                                    new XElement("Section", new XAttribute("SectionId", e.AspNetBranchClass_Sections.AspNetSection.Id),
            //                                                        new XElement("SectionName", e.AspNetBranchClass_Sections.AspNetSection.Name)),
            //                                                    new XElement("Session", new XAttribute("SessionId", e.AspNetSession.Id),
            //                                                        new XElement("SessionYear", new XAttribute("Start", e.AspNetSession.StartDate.ToBinary()), new XAttribute("End", e.AspNetSession.StartDate.ToBinary()),
            //                                                            $"{e.AspNetSession.StartDate:dd MMMM yyyy} - {e.AspNetSession.EndDate:dd MMMM yyyy}")),
            //                                                    new XElement("Branch", new XAttribute("BranchId", e.AspNetBranchClass_Sections.AspNetBranch_Class.AspNetBranch.Id),
            //                                                        e.AspNetBranchClass_Sections.AspNetBranch_Class.AspNetBranch.Name))))))
            //    .ToList();
            //root.Add(students);
            root.Save("students2.xml");
        }
    }
}

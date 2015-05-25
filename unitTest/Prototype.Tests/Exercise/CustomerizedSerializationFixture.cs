using System;
using System.Linq;
using System.Runtime.Serialization;
using MedikzWorks.PracticalPattern.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Prototype.Tests.Exercise
{
    [TestClass]
    public class CustomerizedSerializationFixture
    {
        [Serializable]
        class Project
        {
            /// <summary>
            /// 结项年份
            /// </summary>
            public int EndYear { get; set; }

            /// <summary>
            /// 项目资金规模
            /// </summary>
            public double Scale { get; set; }
        }

        [Flags]
        enum QualificationQptions
        {
            Assisstant, // 助理级
            Professional, // 专家级
            Senior, // 高级、资深级
            Principal // 主人、主管级
        }

        [Serializable]
        class Certification:IComparable<Certification>
        {
            public string Name { get; set; }
            public QualificationQptions Qualification { get; set; }

            public int CompareTo(Certification other)
            {
                if (other == null)
                    throw new ArgumentNullException("other");

                if (!string.Equals(other.Name, Name))
                    throw new NotSupportedException();

                if (Qualification == other.Qualification)
                    return 0;
                return Qualification > other.Qualification ? 1 : -1;
            }
        }

        [Serializable]
        class Employee
        {
            public string Name { get; set; }
            public Certification[] Certificates { get; set; }
        }

        [Serializable]
        class Enterprise:ISerializable
        {
            const string NameItem = "NAME";
            const string ProjectsItem = "PROJECTS";
            const string StaffItem = "STAFF";
            const string ProjectManagerItem = "PM";

            private readonly Certification ProfessalPm =
                new Certification()
                {
                    Name = ProjectManagerItem,
                    Qualification = QualificationQptions.Professional
                };

            public string Name { get; set; }
            public Project[] Projects { get; set; }
            public Employee[] Staff { get; set; }

            public Enterprise()
            {

            }

            protected Enterprise(SerializationInfo info,StreamingContext context)
            {
                Name = info.GetString(NameItem);
                Projects = (Project[])info.GetValue(ProjectsItem, typeof(Project[]));
                Staff = (Employee[])info.GetValue(StaffItem, typeof(Employee[]));
            }

            public Enterprise Clone()
            {
                var graph = SerializationHelper.SerializeObjectToString(this);
                return SerializationHelper.DeserializeStringToObject<Enterprise>(graph);
            }

            /// <summary>
            /// 自定义序列化过程
            /// </summary>
            /// <param name="info"></param>
            /// <param name="context"></param>
            public void GetObjectData(SerializationInfo info, StreamingContext context)
            {
                info.AddValue(NameItem, Name);
                if((Projects != null) && (Projects.Count() > 0))
                {
                    var items = Projects.Where
                        (
                            x =>
                            (DateTime.Now.Year - x.EndYear <= 2)
                            && x.Scale > 3000
                        );
                    if (items != null)
                        info.AddValue(ProjectsItem, items.ToArray());
                }
                if(Staff != null)
                {
                    var items = 
                        from employee in Staff
                        where 
                            (employee.Certificates != null)
                            &&(employee.Certificates.Count()>=0)
                            &&(employee.Certificates.Where(x =>
                                string.Equals(x.Name,ProjectManagerItem) &&
                                x.CompareTo(ProfessalPm) >= 0).Count() > 0)

                            select new Employee()
                            {
                                Name = employee.Name,
                                Certificates = employee.Certificates.Where(x => x.CompareTo(ProfessalPm) > 0).ToArray()
                            };
                    if((items != null) && (items.Count() > 0))
                        info.AddValue(StaffItem,items.ToArray());
                }
            }
        }

        Enterprise enterprise;

        [TestInitialize]
        public void Initialize()
        {
            var thisYear = DateTime.Now.Year;
            enterprise = new Enterprise()
            {
                Name = "A",
                Projects = new Project[]
                                        {
                                            //  金额不符合
                                            new Project() {EndYear = thisYear, Scale = 1500},
                                            //  符合
                                            new Project() {EndYear = thisYear - 1, Scale = 3500},
                                            //  时间不符合
                                            new Project() {EndYear = thisYear - 3, Scale = 5000},
                                            //  符合
                                            new Project() {EndYear = thisYear - 1, Scale = 7500} 
                                        },
                Staff = new Employee[]
                                     {
                                         // PM级别不符合
                                         new Employee(){
                                             Name = "E1", 
                                             Certificates = new Certification[]
                                                                         {
                                                                             new Certification()
                                                                                 {
                                                                                     Name="PM", 
                                                                                     Qualification = QualificationQptions.Assisstant
                                                                                 },
                                                                             new Certification()
                                                                                 {
                                                                                     Name="ARCH", 
                                                                                     Qualification = QualificationQptions.Professional
                                                                                 }
                                                                         }
                                         },
                                         // 符合
                                         new Employee(){
                                             Name = "E2", 
                                             Certificates = new Certification[]
                                                                         {
                                                                             new Certification()
                                                                                 {
                                                                                     Name="PM", 
                                                                                     Qualification = QualificationQptions.Assisstant
                                                                                 },
                                                                             new Certification()
                                                                                 {
                                                                                     Name="PM", 
                                                                                     Qualification = QualificationQptions.Senior
                                                                                 }
                                                                         }
                                         },
                                         // 证书类别不符合
                                         new Employee(){
                                             Name = "E3", 
                                             Certificates = new Certification[]
                                                                         {
                                                                             new Certification()
                                                                                 {
                                                                                     Name="ARCH", 
                                                                                     Qualification = QualificationQptions.Assisstant
                                                                                 },
                                                                             new Certification()
                                                                                 {
                                                                                     Name="ARCH", 
                                                                                     Qualification = QualificationQptions.Senior
                                                                                 }
                                                                         }
                                         },
                                         // 符合
                                         new Employee(){
                                             Name = "E4", 
                                             Certificates = new Certification[]
                                                                         {
                                                                             new Certification()
                                                                                 {
                                                                                     Name="PM", 
                                                                                     Qualification = QualificationQptions.Assisstant
                                                                                 },
                                                                             new Certification()
                                                                                 {
                                                                                     Name="PM", 
                                                                                     Qualification = QualificationQptions.Professional
                                                                                 },
                                                                             new Certification()
                                                                                 {
                                                                                     Name="PM", 
                                                                                     Qualification = QualificationQptions.Assisstant
                                                                                 },
                                                                             new Certification()
                                                                                 {
                                                                                     Name="PM", 
                                                                                     Qualification = QualificationQptions.Principal
                                                                                 }
                                                                         }
                                         },
                                         
                                     }
            };
        }

        [TestMethod]
        public void Test()
        {
            Initialize();
            var clone = enterprise.Clone();
            Assert.AreEqual<string>(enterprise.Name, clone.Name);

            // 企业结项项目信息
            Assert.AreEqual<int>(2, clone.Projects.Count());

            // 企业人员信息
            Assert.AreEqual<int>(2, clone.Staff.Count());
        }
    }
}

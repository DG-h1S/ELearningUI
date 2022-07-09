using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ELearningUI.Models
{
    public partial class ELearningContext : DbContext
    {
        public ELearningContext()
        {
        }

        public ELearningContext(DbContextOptions<ELearningContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Assessment> Assessments { get; set; } = null!;
        public virtual DbSet<Assignment> Assignments { get; set; } = null!;
        public virtual DbSet<Calender> Calenders { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseMaterial> CourseMaterials { get; set; } = null!;
        public virtual DbSet<Deparrtment> Deparrtments { get; set; } = null!;
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
        public virtual DbSet<Exam> Exams { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Lecturer> Lecturers { get; set; } = null!;
        public virtual DbSet<ProgramType> ProgramTypes { get; set; } = null!;
        public virtual DbSet<Quiz> Quizzes { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DG;Database=E-Learning;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("Admin");

                entity.Property(e => e.AdminId).HasColumnName("Admin_Id");

                entity.Property(e => e.Address)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fname)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gname)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId).HasColumnName("Status_Id");

                entity.Property(e => e.Uname)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Admins)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Admin_Status");
            });

            modelBuilder.Entity<Assessment>(entity =>
            {
                entity.ToTable("Assessment");

                entity.Property(e => e.AssessmentId).HasColumnName("Assessment_Id");

                entity.Property(e => e.AssessmentCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Assessment_Code");

                entity.Property(e => e.AssignmentId).HasColumnName("Assignment_Id");

                entity.Property(e => e.Attendance)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ExamId).HasColumnName("Exam_Id");

                entity.Property(e => e.LecturerId).HasColumnName("Lecturer_id");

                entity.Property(e => e.QuizId).HasColumnName("Quiz_Id");

                entity.HasOne(d => d.Assignment)
                    .WithMany(p => p.Assessments)
                    .HasForeignKey(d => d.AssignmentId)
                    .HasConstraintName("FK_Assessment_Assignment1");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.Assessments)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("FK_Assessment_Exam");

                entity.HasOne(d => d.Lecturer)
                    .WithMany(p => p.Assessments)
                    .HasForeignKey(d => d.LecturerId)
                    .HasConstraintName("FK_Assessment_Lecturer");

                entity.HasOne(d => d.Quiz)
                    .WithMany(p => p.Assessments)
                    .HasForeignKey(d => d.QuizId)
                    .HasConstraintName("FK_Assessment_Quiz1");
            });

            modelBuilder.Entity<Assignment>(entity =>
            {
                entity.ToTable("Assignment");

                entity.Property(e => e.AssignmentId).HasColumnName("Assignment_Id");

                entity.Property(e => e.Point)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.SubmitDate)
                    .HasMaxLength(10)
                    .HasColumnName("Submit_date")
                    .IsFixedLength();

                entity.Property(e => e.TimeLimit)
                    .HasColumnType("date")
                    .HasColumnName("Time_Limit");
            });

            modelBuilder.Entity<Calender>(entity =>
            {
                entity.ToTable("Calender");

                entity.Property(e => e.CalenderId).HasColumnName("Calender_Id");

                entity.Property(e => e.CalenderName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Calender_Name");

                entity.Property(e => e.EndDate)
                    .HasMaxLength(10)
                    .HasColumnName("End_Date")
                    .IsFixedLength();

                entity.Property(e => e.EnrollmentId).HasColumnName("Enrollment_Id");

                entity.Property(e => e.ProgramId).HasColumnName("Program_Id");

                entity.Property(e => e.StartDate)
                    .HasMaxLength(10)
                    .HasColumnName("Start_Date")
                    .IsFixedLength();

                entity.HasOne(d => d.Enrollment)
                    .WithMany(p => p.Calenders)
                    .HasForeignKey(d => d.EnrollmentId)
                    .HasConstraintName("FK_Calender_Enrollment");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.Calenders)
                    .HasForeignKey(d => d.ProgramId)
                    .HasConstraintName("FK_Calender_Programs");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId).HasColumnName("Course_Id");

                entity.Property(e => e.CourseCode)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Course_Code");

                entity.Property(e => e.CourseCreditHour).HasColumnName("Course_Credit_hour");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Course_Name");
            });

            modelBuilder.Entity<CourseMaterial>(entity =>
            {
                entity.ToTable("Course Material");

                entity.Property(e => e.CourseMaterialId).HasColumnName("Course_Material_Id");

                entity.Property(e => e.CourseId).HasColumnName("Course_Id");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.File).IsUnicode(false);

                entity.Property(e => e.LectureId).HasColumnName("Lecture_Id");

                entity.Property(e => e.MaterialName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Material_Name");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.CourseMaterials)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Course Material_Course");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.CourseMaterials)
                    .HasForeignKey(d => d.LectureId)
                    .HasConstraintName("FK_Course Material_Lecturer");
            });

            modelBuilder.Entity<Deparrtment>(entity =>
            {
                entity.HasKey(e => e.DepartmentId);

                entity.ToTable("Deparrtment");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

                entity.Property(e => e.DepartmentCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Department_Code");

                entity.Property(e => e.DepartmentName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Department_Name");

                entity.Property(e => e.ProgramId).HasColumnName("Program_Id");

                entity.Property(e => e.TotalCourse)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Total_Course");

                entity.Property(e => e.TotalCreditHr).HasColumnName("Total_Credit_hr");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.Deparrtments)
                    .HasForeignKey(d => d.ProgramId)
                    .HasConstraintName("FK_Deparrtment_Programs");
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.ToTable("Enrollment");

                entity.Property(e => e.EnrollmentId).HasColumnName("Enrollment_Id");

                entity.Property(e => e.CourseId).HasColumnName("Course_Id");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

                entity.Property(e => e.ProgramId).HasColumnName("Program_Id");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Enrollment_Course");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Enrollment_Deparrtment");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.ProgramId)
                    .HasConstraintName("FK_Enrollment_Programs");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("Exam");

                entity.Property(e => e.ExamId)
                    .ValueGeneratedNever()
                    .HasColumnName("Exam_Id");

                entity.Property(e => e.ExamCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Exam_Code");

                entity.Property(e => e.Point).ValueGeneratedOnAdd();

                entity.Property(e => e.TimeClose).HasColumnName("TIme_Close");

                entity.Property(e => e.TimeLimit).HasColumnName("Time_Limit");

                entity.Property(e => e.TimeStart).HasColumnName("Time_Start");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.ToTable("Grade");

                entity.Property(e => e.GradeId).HasColumnName("Grade_Id");

                entity.Property(e => e.AssessmentId).HasColumnName("Assessment_Id");

                entity.Property(e => e.CourseId).HasColumnName("Course_Id");

                entity.Property(e => e.GradeInLetter)
                    .HasMaxLength(10)
                    .HasColumnName("Grade_In_letter")
                    .IsFixedLength();

                entity.HasOne(d => d.Assessment)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.AssessmentId)
                    .HasConstraintName("FK_Grade_Assessment");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK_Grade_Course");
            });

            modelBuilder.Entity<Lecturer>(entity =>
            {
                entity.ToTable("Lecturer");

                entity.Property(e => e.LecturerId).HasColumnName("Lecturer_Id");

                entity.Property(e => e.Address)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EnrollmentId).HasColumnName("Enrollment_Id");

                entity.Property(e => e.Fname)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gfname)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("GFname");

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProgramId).HasColumnName("Program_Id");

                entity.Property(e => e.StatusId).HasColumnName("Status_Id");

                entity.Property(e => e.Uname)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Lecturers)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Lecturer_Deparrtment");

                entity.HasOne(d => d.Enrollment)
                    .WithMany(p => p.Lecturers)
                    .HasForeignKey(d => d.EnrollmentId)
                    .HasConstraintName("FK_Lecturer_Enrollment1");

                entity.HasOne(d => d.Program)
                    .WithMany(p => p.Lecturers)
                    .HasForeignKey(d => d.ProgramId)
                    .HasConstraintName("FK_Lecturer_Programs1");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Lecturers)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Lecturer_Status");
            });

            modelBuilder.Entity<ProgramType>(entity =>
            {
                entity.HasKey(e => e.ProgramId)
                    .HasName("PK_Program");

                entity.ToTable("ProgramType");

                entity.Property(e => e.ProgramId).HasColumnName("Program_Id");

                entity.Property(e => e.ProgramCode)
                    .HasMaxLength(50)
                    .HasColumnName("Program_Code");

                entity.Property(e => e.ProgramName)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("Program_Name");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("Quiz");

                entity.Property(e => e.QuizId).HasColumnName("Quiz_Id");

                entity.Property(e => e.QuizCode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Quiz_Code");

                entity.Property(e => e.TimeClose).HasColumnName("Time_Close");

                entity.Property(e => e.TimeLimit).HasColumnName("Time_Limit");

                entity.Property(e => e.TimeStart).HasColumnName("Time_Start");
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.ScheduleId).HasColumnName("Schedule_Id");

                entity.Property(e => e.AdminId).HasColumnName("Admin_Id");

                entity.Property(e => e.AssessmentId).HasColumnName("Assessment_Id");

                entity.Property(e => e.CourseStartDateTime)
                    .HasMaxLength(10)
                    .HasColumnName("Course_Start_Date_Time")
                    .IsFixedLength();

                entity.Property(e => e.LectureId).HasColumnName("Lecture_Id");

                entity.Property(e => e.StudentId).HasColumnName("Student_Id");

                entity.HasOne(d => d.Admin)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.AdminId)
                    .HasConstraintName("FK_Schedule_Admin");

                entity.HasOne(d => d.Assessment)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.AssessmentId)
                    .HasConstraintName("FK_Schedule_Assessment");

                entity.HasOne(d => d.Lecture)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.LectureId)
                    .HasConstraintName("FK_Schedule_Lecturer");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK_Schedule_Student");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.StatusId).HasColumnName("Status_Id");

                entity.Property(e => e.DateOfJoin)
                    .HasColumnType("date")
                    .HasColumnName("Date_Of_Join");

                entity.Property(e => e.LastLoginDate)
                    .HasColumnType("date")
                    .HasColumnName("Last_Login_Date");

                entity.Property(e => e.LastLoginIp)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Last_Login_Ip");

                entity.Property(e => e.Status1)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Status");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentId).HasColumnName("Student_Id");

                entity.Property(e => e.Address)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.AssessmentId).HasColumnName("Assessment_Id");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("Date_Of_Birth");

                entity.Property(e => e.DepartmentId).HasColumnName("Department_Id");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EnrollmentId).HasColumnName("Enrollment_Id");

                entity.Property(e => e.Fname)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gfname)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("GFname");

                entity.Property(e => e.GradeId).HasColumnName("Grade_Id");

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProgramId).HasColumnName("Program_Id");

                entity.Property(e => e.StatusId).HasColumnName("Status_Id");

                entity.Property(e => e.Uname)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Assessment)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.AssessmentId)
                    .HasConstraintName("FK_Student_Assessment");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK_Student_Deparrtment");

                entity.HasOne(d => d.Enrollment)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.EnrollmentId)
                    .HasConstraintName("FK_Student_Enrollment");

                entity.HasOne(d => d.Grade)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.GradeId)
                    .HasConstraintName("FK_Student_Grade");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Student_Programs");

                entity.HasOne(d => d.StatusNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.StatusId)
                    .HasConstraintName("FK_Student_Status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

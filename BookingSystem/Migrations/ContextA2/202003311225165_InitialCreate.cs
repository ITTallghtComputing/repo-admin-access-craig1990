namespace BookingSystem.Migrations.ContextA2
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RollNumber = c.String(),
                        OfficialSchoolName = c.String(nullable: false),
                        TeacherName = c.String(nullable: false),
                        Address1 = c.String(nullable: false),
                        Address2 = c.String(nullable: false),
                        Address3 = c.String(),
                        Address4 = c.String(),
                        Eircode = c.String(),
                        County = c.String(),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Date = c.DateTime(),
                        StartTime = c.String(nullable: false),
                        EndTime = c.String(nullable: false),
                        Surveys = c.Boolean(),
                        AcademicYear = c.String(),
                        LocalAuthority = c.String(),
                        X = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Y = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ITMEast = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ITMNorth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClassGroups = c.String(nullable: false),
                        Topics = c.String(nullable: false),
                        LecturerName = c.String(),
                        PrincipalName = c.String(),
                        DeisSchool = c.String(),
                        SchoolGender = c.String(),
                        PupilAttendanceType = c.String(),
                        IrishClassification = c.String(),
                        GaeltachtArea = c.String(),
                        FeePayingSchool = c.String(),
                        Religion = c.String(),
                        OpenClosedStatus = c.String(),
                        TotalGirls = c.Int(nullable: false),
                        TotalBoys = c.Int(nullable: false),
                        TotalPupils = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CampDates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        LecturerName = c.String(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompletedCamps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RollNumber = c.String(),
                        OfficialSchoolName = c.String(nullable: false),
                        TeacherName = c.String(nullable: false),
                        Address1 = c.String(nullable: false),
                        Address2 = c.String(nullable: false),
                        Address3 = c.String(),
                        Address4 = c.String(),
                        Eircode = c.String(),
                        County = c.String(),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Date = c.DateTime(),
                        StartTime = c.String(nullable: false),
                        EndTime = c.String(nullable: false),
                        Surveys = c.Boolean(),
                        AcademicYear = c.String(),
                        LocalAuthority = c.String(),
                        X = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Y = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ITMEast = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ITMNorth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClassGroups = c.String(nullable: false),
                        Topics = c.String(nullable: false),
                        LecturerName = c.String(),
                        PrincipalName = c.String(),
                        DeisSchool = c.String(),
                        SchoolGender = c.String(),
                        PupilAttendanceType = c.String(),
                        IrishClassification = c.String(),
                        GaeltachtArea = c.String(),
                        FeePayingSchool = c.String(),
                        Religion = c.String(),
                        OpenClosedStatus = c.String(),
                        TotalGirls = c.Int(nullable: false),
                        TotalBoys = c.Int(nullable: false),
                        TotalPupils = c.Int(nullable: false),
                        SurveyName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Organisations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfficialSchoolName = c.String(),
                        TeacherName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        Address4 = c.String(),
                        Eircode = c.String(),
                        County = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Date = c.DateTime(),
                        StartTime = c.String(),
                        EndTime = c.String(),
                        Surveys = c.Boolean(),
                        ClassGroups = c.String(),
                        Topics = c.String(),
                        ValidationMsg = c.String(),
                        LecturerName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.School2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RollNumber = c.String(),
                        OfficialSchoolName = c.String(),
                        TeacherName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        Address4 = c.String(),
                        Eircode = c.String(),
                        County = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Date = c.DateTime(),
                        StartTime = c.String(),
                        EndTime = c.String(),
                        Surveys = c.Boolean(),
                        AcademicYear = c.String(),
                        LocalAuthority = c.String(),
                        X = c.Decimal(precision: 18, scale: 2),
                        Y = c.Decimal(precision: 18, scale: 2),
                        ITMEast = c.Decimal(precision: 18, scale: 2),
                        ITMNorth = c.Decimal(precision: 18, scale: 2),
                        Latitude = c.Decimal(precision: 18, scale: 2),
                        Longitude = c.Decimal(precision: 18, scale: 2),
                        ClassGroups = c.String(),
                        Topics = c.String(),
                        ValidationMsg = c.String(),
                        LecturerName = c.String(),
                        PrincipalName = c.String(),
                        DeisSchool = c.String(),
                        SchoolGender = c.String(),
                        PupilAttendanceType = c.String(),
                        IrishClassification = c.String(),
                        GaeltachtArea = c.String(),
                        FeePayingSchool = c.String(),
                        Religion = c.String(),
                        OpenClosedStatus = c.String(),
                        TotalGirls = c.Int(),
                        TotalBoys = c.Int(),
                        TotalPupils = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RollNumber = c.String(nullable: false),
                        OfficialSchoolName = c.String(),
                        TeacherName = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Address3 = c.String(),
                        Address4 = c.String(),
                        Eircode = c.String(),
                        County = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Date = c.DateTime(),
                        StartTime = c.String(),
                        EndTime = c.String(),
                        Surveys = c.Boolean(),
                        AcademicYear = c.String(),
                        LocalAuthority = c.String(),
                        X = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Y = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ITMEast = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ITMNorth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Longitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClassGroups = c.String(),
                        Topics = c.String(),
                        ValidationMsg = c.String(),
                        LecturerName = c.String(),
                        PrincipalName = c.String(),
                        DeisSchool = c.String(),
                        SchoolGender = c.String(),
                        PupilAttendanceType = c.String(),
                        IrishClassification = c.String(),
                        GaeltachtArea = c.String(),
                        FeePayingSchool = c.String(),
                        Religion = c.String(),
                        OpenClosedStatus = c.String(),
                        TotalGirls = c.Int(),
                        TotalBoys = c.Int(),
                        TotalPupils = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SecondarySchoolSurveys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Q1 = c.Double(nullable: false),
                        RollNumber = c.String(),
                        OfficialSchoolName = c.String(),
                        CampDate = c.DateTime(),
                        SurveyFileName = c.String(),
                        FilePage = c.Int(nullable: false),
                        Q2 = c.Int(nullable: false),
                        Q3 = c.String(),
                        Q4 = c.String(),
                        Q5 = c.String(),
                        Q6a = c.Int(nullable: false),
                        Q6b = c.String(),
                        Q7 = c.Int(nullable: false),
                        Q8 = c.String(),
                        Q9 = c.Int(nullable: false),
                        Q10 = c.Int(nullable: false),
                        Q11 = c.String(),
                        Q12 = c.String(),
                        Q13a = c.Int(nullable: false),
                        Q13b = c.String(),
                        Q14a = c.Int(nullable: false),
                        Q14b = c.Int(nullable: false),
                        Q14c = c.String(),
                        Q15 = c.Int(nullable: false),
                        Q16 = c.Int(nullable: false),
                        Q17 = c.Int(nullable: false),
                        Q18 = c.String(),
                        Q19 = c.Int(nullable: false),
                        Q20 = c.String(),
                        Flag = c.Boolean(nullable: false),
                        FlagContent = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SecondarySchoolSurveys");
            DropTable("dbo.Schools");
            DropTable("dbo.School2");
            DropTable("dbo.Organisations");
            DropTable("dbo.CompletedCamps");
            DropTable("dbo.CampDates");
            DropTable("dbo.Bookings");
        }
    }
}

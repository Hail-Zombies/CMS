CREATE TABLE [dbo].[Articles] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Title]       NVARCHAR (200) NOT NULL,
    [Author]      NVARCHAR (50)  NOT NULL,
    [Content]     NVARCHAR (MAX) NOT NULL,
    [Update_time] DATETIME       NOT NULL,
    [Class]       NVARCHAR (50)  NOT NULL,
    [Abstract]    NVARCHAR (500) NOT NULL,
    [Content_HASH] BINARY(32) NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Departments]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [dept_id] NVARCHAR(10) NOT NULL, 
    [dept_name] NVARCHAR(100) NOT NULL, 
    [dept_parent_id] NVARCHAR(11) NOT NULL, 
    [dept_parent_ids] NVARCHAR(255) NOT NULL
)

INSERT INTO Departments(dept_id,dept_name,dept_parent_id,dept_parent_ids)
     VALUES
           ('101','一级部门01','0','0'),
           ('102','一级部门01','0','0'),
           ('103','一级部门01','0','0'),
           ('20101','二级部门0101','101','0,101'),
           ('20102','二级部门0102','101','0,101'),
           ('20103','二级部门0103','101','0,101'),
           ('20201','二级部门0201','102','0,102'),
           ('20202','二级部门0202','102','0,102'),
           ('20203','二级部门0203','102','0,102'),
           ('20301','二级部门0301','103','0,103'),
           ('20302','二级部门0302','103','0,103'),
           ('20303','二级部门0303','103','0,103')
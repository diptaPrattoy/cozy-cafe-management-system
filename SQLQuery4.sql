
CREATE TABLE Project_User (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(255) NULL,
    Password VARCHAR(255) NULL,
    Profile_Image VARCHAR(255) NULL,
    Role VARCHAR(255) NULL,
    Status VARCHAR(255) NULL,
    Date_Reg DATE NULL
);



SELECT * FROM project_user;

INSERT INTO project_user (username, password, profile_image, role, status, date_reg) VALUES ('Admin', 'admin123', '', 'Admin', 'Active', '2025-02-03');



DROP TABLE Project_User ;

SELECT * FROM project_user WHERE status = 'Approval';
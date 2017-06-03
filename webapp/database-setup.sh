sqlcmd -S "O.O.O.O,1433" -U "SA" -P $SA_PASSWORD -d "master" -Q "CREATE DATABASE [TotalSolution];"

sqlcmd -S "0.0.0.0,1433" -U "SA" -P $SA_PASSWORD -d "TotalSolution" -Q "CREATE TABLE [posts](id INT IDENTITY(1,1) NOT NULL, title VARCHAR(50), body VARCHAR(200), created_at DateTime NOT NULL, updated_at DateTime NOT NULL);"
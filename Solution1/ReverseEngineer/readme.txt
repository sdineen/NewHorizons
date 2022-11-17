Add the following using NuGet
•	Microsoft.EntityFrameworkCore.Design
•	Microsoft.EntityFrameworkCore.Tools
•	Microsoft.EntityFrameworkCore.SqlServer
Open the package manger console and run this command 
Scaffold-DbContext 'Data Source=.\sqlexpress;Initial Catalog=ecommerce;User ID=sa;Password=carpond' Microsoft.EntityFrameworkCore.SqlServer

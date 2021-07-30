# create a database
# change connection string in appsettings.json and ~/DataAccess/Database ConnectionString inside Web project
# I'm using role based authentication
# I'm seeding Admin User & Roles,
  userName = adminuser@gmail.com
  password = Admin123@@
  
  for insert Subscription package execute sql query :
  insert into SubscriptionTypes values('Standard', '2021-07-30 11:21:43.8231472', 'Standard package', 'standard', 120, 6);
  insert into SubscriptionTypes values('Special', '2021-07-30 11:21:43.8231472', 'Special package', 'special', 120, 6);
  insert into SubscriptionTypes values('Company', '2021-07-30 11:21:43.8231472', 'Company package', 'company', 120, 6);
  


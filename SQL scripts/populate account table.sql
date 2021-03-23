insert into BankingDb.[dbo].[Accounts]
values ('Transfer', 0),
       ('Saving', 300)

insert into TransferDb.dbo.TransferLogs
values(1,2, 100),
      (1,2, 200),
      (2,3, 50),
      (2,1, 50)

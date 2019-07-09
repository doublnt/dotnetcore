select * from dbo.orders;

select empid, orderid, qty, year(orderts) as orderyear, count(*) as numorders
from dbo.orders
where orderid = 76
group by empid, year(orderts)
having count(*) > 1
order by empid, orderyear;
select customer_number from (select customer_number, count(*) as ordercount from orders group by customer_number order by ordercount desc limit 1 ) as newtable;
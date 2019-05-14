#Imcomplete solution for situation where no answer exists
select num from
(select num, count(num) as numcount from my_numbers group by num) as newtable 
where numcount=1 order by num desc limit 1;

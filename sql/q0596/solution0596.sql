#Need to select Count(Distinct )
select class from (select class, count(distinct student) as studentcount from courses group by class) as newtable where studentcount >= 5;
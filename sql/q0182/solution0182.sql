select Email from (select Email, Count(*) as cnt from Person group by Email ) as duplicates where cnt>1;
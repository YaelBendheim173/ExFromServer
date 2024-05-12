select u.university_name, ury.year, rc.criteria_name, ury.score, rs.system_name
from university_ranking_year as ury
join university as u
on u.id=ury.university_id
join ranking_criteria as rc
on rc.id=ury.ranking_criteria_id
join ranking_system as rs
on rs.id=rc.ranking_system_.id
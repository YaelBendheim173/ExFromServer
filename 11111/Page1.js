import { useEffect,useState } from 'react'
import CountriesApi from '../HOC/Api';
import './style.css'
function Page1(props){
  const countries=props.countries;
  const universities=props.universities;
  const years=props.years;
  const [cval,setcval]=useState(null);
  const [uval,setuval]=useState(null);
  const [yval,setyval]=useState(null);
  const [searchResults, setSearchResults] = useState([]);
  const handleSearch = async () => {
 // const url="http://localhost:5148/api/ury?PageSize=4";

    const baseUrl = "https://localhost:7091/api/ury?PageSize=4";
// const countryId = "123"; // לדוגמה, משתנה עם ה-ID של המדינה
// const universityName = "Tel Aviv University"; // לדוגמה, משתנה עם שם האוניברסיטה
// const year = "2024"; // לדוגמה, משתנה עם השנה

if (cval!=null) {
  baseUrl=`${baseUrl}+&CountryId=${cval}`;
  //const url = `${baseUrl}?CountryId=${cval}`;
}
// if (uval!=null) {
//   baseUrl= `${baseUrl}+&UniversityName=${uval}`;
// }
// if (yval!=null) {
//   baseUrl= `${baseUrl}+&Year=${yval}`;
// }


    try {
      const response = await fetch(baseUrl);
      const data = await response.json();
      console.log(data)
      setSearchResults(data);
      // Do something with the data
    } catch (error) {
      console.error("Error fetching data:", error);
    }
  };
  
    return <>
      <div id='inputs'>
      <select onChange={(e) => setcval(e.target.value)}>
      {countries.map((c,index)=>(
        <option key={index} value={c.id}>{c.countryName}</option>
      ))}
      </select>
      <select onChange={(e) => setuval(e.target.value)}>
      {universities.map((u,index)=>(
        <option key={index} value={u.universityName}>{u.universityName}</option>
      ))}
      </select>
      <select onChange={(e) => setyval(e.target.value)}>
      {years.map((y,index)=>(
        <option key={index} value={y}>{y}</option>
      ))}
      </select>
      <button onClick={handleSearch}>search</button>
      </div>
    <div id='response'>
    {Array.isArray(searchResults) && searchResults.map((d, index) => (
          <table className='table table-dark'>
            <tbody>
              <tr key={index}>
                <td><h3>UniversityName:</h3> <h4>{d.universityName}</h4></td>
                <td><h3>Year:</h3> <h4>{d.year}</h4> </td>
                <td><h3>CriteriaName:</h3> <h4>{d.criteriaName}</h4></td>
                <td><h3>Score:</h3> <h4>{d.score}</h4></td>
                <td><h3>SystemName:</h3> <h4>{d.systemName}</h4></td>
                <td><h3>CountryId:</h3> <h4>{d.countryId}</h4></td>
              </tr>
            </tbody>
          </table>
        ))
      
      }
    </div>
</>
};
export default CountriesApi(Page1);
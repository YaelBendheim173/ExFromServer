import React from "react";
import { useEffect,useState } from 'react'
const CountriesApi=(OriginalComponent)=>{
    function NewComponent(){
  const [cdata,setcdata]=useState([]);
  const [udata,setudata]=useState([]);
  //const [ydata,setydata]=useState([]);
  const [years,setyears]=useState([2010,2011,2012,2013,2014,2015]);
  useEffect(()=>{
    const url1="http://localhost:5148/api/countries";
    const fetchData1=async()=>{
      try{
        const response=await fetch(url1);
        const resJson=await response.json();
        //console.log(resJson);
        setcdata(resJson);
      }catch(error){
        alert("c_error");
      }
    };
    fetchData1();

    const url2="http://localhost:5148/api/universities";
    const fetchData2=async()=>{
      try{
        const response=await fetch(url2);
        const resJson=await response.json();
        //console.log(resJson);
        setudata(resJson);
      }catch(error){
        alert("u_error");
      }
    };
    fetchData2();

    // const url3="http://localhost:5148/api/ury";
    // const fetchData3=async()=>{
    //   try{
    //     const response=await fetch(url3);
    //     const resJson=await response.json();
    //     //console.log(resJson);
    //     setydata(resJson);
    //   }catch(error){
    //     alert("y_error");
    //   }
    // };
    // fetchData3();
  },[]);
        return <OriginalComponent countries={cdata} universities={udata} years={years}/>;
    }
    return NewComponent;
}
export default CountriesApi;
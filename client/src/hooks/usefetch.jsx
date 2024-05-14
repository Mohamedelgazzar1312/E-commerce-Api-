import { faL } from "@fortawesome/free-solid-svg-icons"
import { setDate } from "date-fns"
import { useEffect,useState } from "react"
import axios from "axios"

const useFetch=(url)=>{
    const [data,setData]=useState([])
    const [loading,setLoading]=useState(false)
    const [error,setError]=useState(false)
    const [dataLoaded, setDataLoaded] = useState(false);
    
    useEffect(()=>{  
        const fetchData= async()=>{
            setLoading(true)
           try {
            
               const res= await axios.get(url)
               setData(res.data)
               setDataLoaded(true);
           } catch (err) {
            setError(err)
           } 
           setLoading(false)
        };
        fetchData()
    },[])

const reFetch=async ()=>{
    setLoading(true);
           try {
               const res= await axios.get(url)
               setData(res.data)
               setLoading(true);
           } catch (err) {
            setError(err)
           } 
           setLoading(false);
        };
        return {data,loading,error,reFetch,dataLoaded}
    


 };

        
export default useFetch;


// import { useEffect, useState } from "react";
// import axios from "axios";

// const useFetch = (url) => {
//   const [data, setData] = useState([]);
//   const [loading, setLoading] = useState(false);
//   const [error, setError] = useState(false);
//   const [dataLoaded, setDataLoaded] = useState(false);

//   useEffect(() => {
//     const fetchData = async () => {
//       setLoading(true);
//       try {
//         const res = await axios.get(url);
//         setData(res.data);
//         setDataLoaded(true);
//       } catch (err) {
//         setError(err);
//       }
//       setLoading(false);
//     };
//     fetchData();
//   }, [url]);

//   const reFetch = async () => {
//     setLoading(true);
//     try {
//       const res = await axios.get(url);
//       setData(res.data);
//       setLoading(false);
//     } catch (err) {
//       setError(err);
//     }
//     setLoading(false);
//   };

//   return { data, loading, error, reFetch, dataLoaded };
// };

// export default useFetch;

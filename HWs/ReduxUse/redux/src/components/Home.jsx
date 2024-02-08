import { useEffect } from "react"
import { useSelector, useDispatch } from "react-redux"
import { fetchContent } from "../redux/reducer"
import Sentry from "react-activity/dist/Sentry";
import "react-activity/dist/Sentry.css";

function Home({query}) { 
  let usersArray = useSelector((state) => state.goods.goodsArray)
  let loading = useSelector((state) => state.goods.isLoading)
  let error = useSelector((state) => state.goods.error)
  let dispatch = useDispatch()
  useEffect(() => {
    dispatch(fetchContent())
  },[])
  if(loading){
    return <Sentry />
  }
  return (
    <div >
      <h1>ALL GOODS</h1>
        <ul className="goods">
        {usersArray.map((item) => {
          return(
          <li key={item.id}>
            <p>{item.product_name}</p>
            <p>{item.product_description}</p>
            <p>{item.product_price}</p>
            <p>{item.store_name}</p>
            <p>{item.store_address}</p>
          </li>
          )
        })}
        </ul>
    </div>
  )
}

export default Home
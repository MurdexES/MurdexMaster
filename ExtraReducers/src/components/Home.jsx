import { useEffect } from "react";
import { useSelector, useDispatch } from "react-redux";
import { fetchContent } from "../redux/reducer";
import Spinner from 'react-bootstrap/Spinner'

function Home(){
    let usersArray = useSelector((state) => state.goods.usersArray)
    let loading = useSelector((state) => state.goods.isLoading)
    let error = useSelector((state) => state.goods.error)

  let dispatch = useDispatch()

  useEffect(() => {
    dispatch(fetchContent())
  }, [])

  if (loading) {
    return (
        <>
        <div className="admin-modal-container">
            <SyncLoader color="#36d7b7" />
        </div>
        </>
    )
  }

  if (error) {
    return (
      <div className="admin-modal-container">

        <h1>ERROR...</h1>
      </div>

    )
  }
  return (
    <div >
      <h1>ALL GOODS</h1>
      <ul className="goods">
        {usersArray.map((item) => {
          return (
            <li key={item.id}>
              <p>{item.product_name}</p>
              <p>{item.product_description}</p>
              <p>{item.product_price}</p>
              <p>{item.store_name}</p>
              <p>{item.store_address}</p>
              <button>ADD TO BAG</button>
            </li>
          )
        })}
      </ul>
    </div>
  )
}

export default Home
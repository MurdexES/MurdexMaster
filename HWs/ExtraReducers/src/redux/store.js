import { configureStore } from '@reduxjs/toolkit'
import goodsSlice from './reducer'

let applicationStore = configureStore({
    reducer:{
        gooods: goodsSlice,
    }
})

export default applicationStore
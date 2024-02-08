import { configureStore } from '@reduxjs/toolkit'
import goodsSlice from './reducer.js'
const applicationStore = configureStore({
    reducer: {
        goods: goodsSlice
    }
})

export default applicationStore
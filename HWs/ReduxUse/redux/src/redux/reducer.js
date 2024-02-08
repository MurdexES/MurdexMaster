import { createSlice, createAsyncThunk } from "@reduxjs/toolkit"

export const fetchContent = createAsyncThunk(
    'goods/fetchContent',
    async () => {
        const response = await fetch('http://localhost:5000/goods')
        const data = await response.json()
        return data
    })
const goodsSlice = createSlice({
        name: 'goods',
        initialState: {
            goods: [],
            addInfo: '',
            deleteInfo: '',
            isLoading: false,
            error: null
        },
        reducers: {
            addingData(state, action){
                return {...state,goods: action.payload}
            },
            deletingData(state, action){
                return {...state,goods: action.payload}
            },
            editingData(state, action){
                return {...state,goods: action.payload}
            }
        },
        extraReducers: (builder) => {
            builder.addCase(fetchContent.pending, (state, action) => {
                state.isLoading = true
            }),
            builder.addCase(fetchContent.fulfilled, (state, action) => {
                state.isLoading = false
                state.goods = action.payload
            }),
            builder.addCase(fetchContent.rejected, (state, action) => {
                state.isLoading = false
                state.error = true
            })
        }
})

export const { addingData, deletingData, editingData } = goodsSlice.actions
export default goodsSlice.reducer
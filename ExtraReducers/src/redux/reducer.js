import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";

export const fetchContent = createAsyncThunk(
    'content/fetchContent',
    async () => {
        const res = await fetch('http://localhost:5000/goods')
        const data = await res.json()
        return data
    }
)
    const goodsSlice = createSlice({
        name: "goods",
        initialState: {
            userArray: [],
            addingInfo: '',
            deleteInfo: '',
            isLoading: false,
            errror: null
        },
        reducers:{
            addingData: (state, action) => {
                return {...state, addingInfo: action.payload}
            },
            deletingData: (state, action) => {
                return {...state, deleteInfo: action.payload}
            },
        },
        extraReducers: (builder) => {
            builder.addCase(fetchContent.pending, (state) =>{
                state.isLoading = true
            })

            builder.addCase(fetchContent.fulfilled, (state, action) =>{
                state.usersArray = action.payload
                state.isLoading = false
            })

            builder.addCase(fetchContent.rejected, (state, action) =>{
                state.isLoading = false
                state.errror = true
            })
        },
    })

    export const {addingData, deletingData} = goodsSlice.actions

    export default goodsSlice.reducer

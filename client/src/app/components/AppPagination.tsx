import { Box, Typography, Pagination } from "@mui/material";
import { MetaData } from "../models/pagination";

interface Props {
    metaData: MetaData,
    onPageChange: (page: number) => void;
}

export default function AppPagination({ metaData, onPageChange }: Props) {
    const { pageSize, currentPage, totalCount, totalPages } = metaData;
    return (
        <Box display='flex' justifyContent='space-between' alignItems='center' sx={{ marginBottom: 3 }}>
            <Typography variant='body1'>
                {(currentPage - 1) * pageSize + 1}-
                {currentPage * pageSize > totalCount!
                    ? totalCount
                    : currentPage * pageSize
                } von {totalCount} Ergebnissen
            </Typography>
            <Pagination
                color='primary'
                size='large'
                count={totalPages}
                page={currentPage}
                onChange={(e, page) => onPageChange(page)}
                sx={{ '& .Mui-selected': { backgroundColor: 'blue' } }}
            />
        </Box>
    )
}
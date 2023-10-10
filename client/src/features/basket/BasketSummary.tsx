import { TableContainer, Paper, Table, TableBody, TableRow, TableCell } from "@mui/material";
import { useAppSelector } from "../../app/store/configureStore";
import { currencyFormat } from "../../app/util/util";

interface Props {
    subtotal?: number;
}

export default function BasketSummary({subtotal}: Props) {
    const { basket } = useAppSelector(state => state.basket);
    if (subtotal === undefined) 
        subtotal = basket?.items.reduce((sum, item) => sum + (item.quantity * item.price), 0) ?? 0;
    const deliveryFee = subtotal > 10000 ? 0 : 500;

    return (
        <>
            <TableContainer component={Paper} variant={'outlined'}>
                <Table>
                    <TableBody>
                        <TableRow>
                            <TableCell colSpan={2}>Zwischensumme</TableCell>
                            <TableCell align="right">{currencyFormat(subtotal)}</TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell colSpan={2}>Liefergebühr*</TableCell>
                            <TableCell align="right">{currencyFormat(deliveryFee)}</TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell colSpan={2}>Gesamt</TableCell>
                            <TableCell align="right">{currencyFormat(subtotal + deliveryFee)}</TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell>
                                <span style={{ fontStyle: 'italic' }}>*Bei Bestellungen über 100 € ist die Lieferung kostenlos</span>
                            </TableCell>
                        </TableRow>
                    </TableBody>
                </Table>
            </TableContainer>
        </>
    )
}
<?php

namespace App\Http\Controllers\api;

use App\Http\Controllers\Controller;
use App\Http\Requests\StoreCarRequest;
use App\Http\Requests\StoreRentalRequest;
use App\Http\Requests\UpdateCarRequest;
use App\Models\Car;
use App\Models\Rental;
use Illuminate\Http\Request;

use function PHPUnit\Framework\isEmpty;

class CarController extends Controller
{
    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        $car=Car::all();
        return response()->json(['data'=>$car]);
        
    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\Response
     */
    public function store(StoreCarRequest $request)
    {
        $newcar=new Car();
        $newcar->fill($request->all());
        $newcar->save();
        return response()->json($newcar,201);
    }

    /**
     * Display the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function show($id)
    {
        //
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function update(UpdateCarRequest $request, $id)
    {
        $updatecar=Car::find($id);
        if($id==null){
            return response()->json('Nincs ilyen kocsi az adatbázisban!',404);
        }
        if(empty($updatecar)) {
            return response()->json(["message"=>"Nincs ilyen azonosítójú kocsi $id"]);
        }
        else {
        $updatecar->fill($request->all());
        $updatecar->save();
        return response()->json($updatecar,200);
        }
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function destroy($id)
    {
        //
    }
    public function rent(Request $request, $id){
        $carrent=Car::find($id);
        //return response()->json('rent',200);
        if(empty($carrent)){
            return response()->json(["message"=>'Ezen az indexen nem található autó'],404);
        }
        $rent=date("Y-m-d");
        //return response()->json($rent);
        $rented=Rental::where(
            ["car_id"=>$id],
            //["start_date","<=",date("Y-m-d")],
            ["end_date",">=",date("Y-m-d")], 
        )->get();
        //return response()->json(Rental::where('end_date'));
        if(!$rented->isEmpty()){
            return response()->json(["message"=>"Az adott kocsi le van foglalva"],409);
        }
            $newrent=new Rental();
            $newrent->fill([
                "car_id"=>$id,
                "start_date"=>date("Y-m-d"),
                "end_date"=>date("Y-m-d",strtotime('+7 days')),
                ]
            );
            $newrent->save();
            return response()->json($newrent,201);
        
    }
}

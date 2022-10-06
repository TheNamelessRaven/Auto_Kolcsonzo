<?php

namespace App\Http\Requests;

use Illuminate\Foundation\Http\FormRequest;

class StoreCarRequest extends FormRequest
{
    /**
     * Determine if the user is authorized to make this request.
     *
     * @return bool
     */
    public function authorize()
    {
        return true;
    }

    /**
     * Get the validation rules that apply to the request.
     *
     * @return array<string, mixed>
     */
    public function rules()
    {
        return [
            'license_plate_number'=>"required|min:6|string|",
            'brand'=>"required|string",
            'model'=>'required|string|min:4',
            'daily_cost'=>'required|integer|min:0',
        ];
    }
}

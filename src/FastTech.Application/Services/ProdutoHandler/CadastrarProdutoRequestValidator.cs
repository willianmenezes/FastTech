using FluentValidation;

namespace FastTech.Application.Services.ProdutoHandler;

public class CadastrarProdutoRequestValidator : AbstractValidator<CadastrarProdutoRequest>
{
    public CadastrarProdutoRequestValidator()
    {
        RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("O nome do produto e obrigatorio.")
            .MinimumLength(3).WithMessage("O nome do produto deve ter mais que {MinLength} caracteres.")
            .MaximumLength(200).WithMessage("O nome do produto deve ter menos que {MaxLength} caracteres.");

        RuleFor(p => p.Descricao)
            .NotEmpty().WithMessage("A descricao do produto e obrigatoria.")
            .MinimumLength(3).WithMessage("A descricao do produto deve ter mais que {MinLength} caracteres.")
            .MaximumLength(700).WithMessage("A descricao do produto deve ter menos que {MaxLength} caracteres.");

        RuleFor(p => p.Valor)
            .NotEmpty().WithMessage("O valor do produto e obrigatorio")
            .GreaterThan(0).WithMessage("O valor do produto deve ser maior que {ComparisonValue}. ");

        RuleFor(p => p.QuantidadeEstoque)
            .NotEmpty().WithMessage("A quantidade do estoque e obrigatoria.")
            .GreaterThan(0).WithMessage("A quantidade do estoque ser maior que {ComparisonValue}.");

        RuleFor(p => p.Tipo)
            .NotNull().WithMessage("O tipo e obrigatorio.");
    }
}